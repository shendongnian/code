    public class Account
    {
      public string name;
      public string password;
      public string newInfo;
      public class IndexOfName
      {
        private string _match = "";
        public IndexOfName()
        {
        }
        public Predicate<Account> Match(string match)
        {
          this._match = match;
          return IsMatch;
        }
        private bool IsMatch(Account matchTo)
        {
          if (matchTo == null)
          {
            return false;
          }
          return matchTo.Equals(this._match);
        }
      }
    }
