    public class CustomerBase
    {
        public string Email { get; private set; }
        public bool Active { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        protected void SetAccountInfo(Account account)
        {
            this.Email = account.Email;
            this.Active = account.Active;
            this.FirstName = account.FirstName;
            this.LastName = account.LastName;
        }
    }
    public class CustomerA : CustomerBase
    {
        public string IsAdmin { get; private set; }
        public DateTime? LastLogin { get; private set; }
        public void SetAccountInfo(Account account)
        {
            base.SetAccountInfo(account);
            this.IsAdmin = account.IsAdmin;
            this.LastLogin = account.LastLogin;
        }
    }
     public class Account
    {
         //your properties
        public string Email { get; set; }
        public bool Active { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IsAdmin { get; set; }
        public DateTime? LastLogin { get; set; }
    }
