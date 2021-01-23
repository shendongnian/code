    public sealed class UtilParserHTML
    {
        //Private Fields
        private Uri Uri;
        private Stream StreamPage;
        private HttpWebRequest HttpRequest;
        private HttpWebResponse HttpResponse;
        
        //Public Fields
        public HtmlDocument HtmlDocument { private set; get; }
        public UtilParserHTML()
        {
            if (this.HtmlDocument == null)
                HtmlDocument = new HtmlDocument();
        }
        public void LoadHTMLPage(string UrlPage)
        {
            if (string.IsNullOrEmpty(UrlPage))
                throw new ArgumentNullException("");
            CookieContainer cookieContainer = new CookieContainer();
                    
            this.Uri = new Uri(UrlPage);
            this.HttpRequest = (HttpWebRequest)WebRequest.Create(UrlPage);
            this.HttpRequest.Method = WebRequestMethods.Http.Get;       
            this.HttpRequest.CookieContainer = cookieContainer;
            this.HttpResponse = (HttpWebResponse)this.HttpRequest.GetResponse();
            this.StreamPage = this.HttpResponse.GetResponseStream();
            this.HtmlDocument.Load(StreamPage);
        }
        public void LoadHTMLPage(FileStream StreamPage)
        {
            if (StreamPage == null)
                throw new ArgumentNullException("");
            HtmlDocument.Load(StreamPage);
        }
        public HtmlNodeCollection GetNodesByExpression(string XPathExpression)
        {
            if (string.IsNullOrEmpty(XPathExpression))
                throw new ArgumentNullException("");
            return this.HtmlDocument.DocumentNode.SelectNodes(XPathExpression);
        }
