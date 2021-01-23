    public class FbContact : BaseContact
    {
        private string _baseUrl = "http://facebook.com/{0}";
        private string _url = string.Empty;
        public override string Url
        {
            get { return _url; }
            set { _url = string.Format(_baseUrl, value); }
        }
    }
    public class LinkedInContact : BaseContact
    {
        private string _baseUrl = "http://linkedin.com/{0}";
        private string _url = string.Empty;
        public override string Url
        {
            get { return _url; }
            set { _url = string.Format(_baseUrl, value); }
        }
    }
