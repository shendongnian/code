    [Serializable]
    public class DomainHelper
    {
        private readonly string _domainIWasConstructedIn = AppDomain.CurrentDomain.FriendlyName;
    
        public string GetDomainName()
        {
            return _domainIWasConstructedIn;
        }
    }
