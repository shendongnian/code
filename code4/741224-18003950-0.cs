    public class Account : IEquatable<Account>
    {
        public string name;
        public string password;
        public string newInfo;
        public bool Equals(Account x, Account y)
        {
           //Choose what you want to consider as "equal" between Account objects      
        }
    }
