using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UCDArchTemplates.Models
{
    public class Customer : DomainObjectWithTypedId<string>
    {
        public Customer()
        {
            InitMembers();
        }

        /// <summary>
        /// Creates valid domain object
        /// </summary>
        public Customer(string companyName)
            : this()
        {
            CompanyName = companyName;
        }

        /// <summary>
        /// Since we want to leverage automatic properties, init appropriate members here.
        /// </summary>
        private void InitMembers()
        {
            Orders = new List<Order>();
        }

        [Required]
        public virtual string CompanyName { get; set; }

        [Required]
        public virtual string ContactName { get; set; }

        public virtual string Country { get; set; }
        
        public virtual string Fax { get; set; }

        /// <summary>
        /// Note the protected set...only the ORM should set the collection reference directly
        /// after it's been initialized in <see cref="InitMembers" />
        /// </summary>
        public virtual IList<Order> Orders { get; protected set; }

        public virtual void SetAssignedIdTo(string assignedId)
        {
            //Check.Require(!string.IsNullOrEmpty(assignedId), "assignedId may not be null or empty");
            //Check.Require(assignedId.Trim().Length == 5, "assignedId must be exactly 5 characters");

            Id = assignedId.Trim().ToUpper();
        }

    }
}