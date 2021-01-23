    public class Account
    {
        public int AccountId { get; set; }
        public string UserName { get; set;}
    }
    public class AccountSchool
    {
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        [ForeignKey("School")]
        public string CEEBCodeId { get; set; }
        public string PersonelleID { get; set; }
    }
    public class School
    {
        [Key]
        public string CEEBCodeId { get; set; }
        public string Name { get; set;}
    }
