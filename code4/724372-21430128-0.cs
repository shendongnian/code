    public class UserSessionData
    {
        private string Get(What what)
        {
            throw new NotImplementedException("TODO: Get from external source");
        }
        private void Set(What what, string value)
        {
            throw new NotImplementedException("TODO: Set in external source");
        }
    
        public string CustomerNumber {
            get { return Get(What.CustomerNumber); }
            set { Set(What.CustomerNumber, value); }
        }
    
        // ... 
    }
    
    public enum What
    {
        CustomerNumber, FirstName, LastName, // ...
    }
