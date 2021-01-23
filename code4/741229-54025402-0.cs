    public class Account
    {
      public string name;
      public string password;
      public string newInfo;
      public class IndexOfName
      {
        public IndexOfName(string match)
        {
          Matchstring = match;
        }
        public string Matchstring { get; set; }
        // Gets the predicate. Now it's possible to re-use this predicate with 
        // various matching string.
        public Predicate<Account> Match
        {
          get { return IsMatch; }
        }
        private bool IsMatch(Account account)
        {
          if (account == null)
          {
            return false;
          }
          return string.Compare(account.name, Matchstring, true) == 0;
        }
      }
    }
