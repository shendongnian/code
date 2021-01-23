    [Table("Company")]
    public class Company {
        public virtual List<UserAccount> Users {
            get;
            set;
        }
    }
