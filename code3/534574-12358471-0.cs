    public  class DomainSplitter {
        public string DomainPart { get; private set; }
        public string SubDomainPart { get; private set; }
        public string FirstPart { get; private set; }
        public string QueryPart { get; private set; }
        public DomainSplitter(string url) {
            if (string.IsNullOrEmpty(url)) {
                throw new Exception("urlString or expected sub domain were null or empty");
            }
            if (url.Contains("://")) {
                FirstPart = url.Split(':')[0] + "://";
                url = url.Remove(0, FirstPart.Length);
            }
            var endOfDomainIndex = url.IndexOfAny("?/".ToCharArray());
            if (endOfDomainIndex == -1) {
                endOfDomainIndex = url.Length;
            }
            int startOfDomainIndex;
            var domainStub = url.Substring(0, endOfDomainIndex);
            var noOfDots = domainStub.Length - domainStub.Replace(".", "").Length;
            switch (noOfDots) {
                case 0:
                    startOfDomainIndex = 0;
                    break;
                case 1:
                    startOfDomainIndex = 0;
                    if (url.Contains("localhost")) {
                        startOfDomainIndex = url.IndexOf(".") + 1;
                    }
                    break;
                default:
                    startOfDomainIndex = url.IndexOf(".") + 1;
                    break;
            }
            if (url.Contains("?")) {
                QueryPart = "?" + url.Split('?')[1];    
            }
            else {
                QueryPart = "";
            }
            
            SubDomainPart = startOfDomainIndex > 0 ? url.Substring(0, startOfDomainIndex - 1) : "";
            DomainPart = url.Substring(startOfDomainIndex, endOfDomainIndex - startOfDomainIndex);
           
        }
    }
