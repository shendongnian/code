    public class SoapHttpClientProtocolWithRedirect :
        System.Web.Services.Protocols.SoapHttpClientProtocol
    {
        protected override System.Net.WebRequest GetWebRequest(Uri uri)
        {
            if (!_redirectFixed)
            {
                FixRedirect(new Uri(this.Url));
                _redirectFixed = true;
                return base.GetWebRequest(new Uri(this.Url));
            }
            return base.GetWebRequest(uri);
        }
        private bool _redirectFixed = false;
        private void FixRedirect(Uri uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.CookieContainer = new CookieContainer();
            request.AllowAutoRedirect = false;
            var response = (HttpWebResponse)request.GetResponse();
            switch (response.StatusCode)
            {
                case HttpStatusCode.Redirect:
                case HttpStatusCode.TemporaryRedirect:
                case HttpStatusCode.MovedPermanently:
                    this.Url = new Uri(uri, response.Headers["Location"]).ToString();
                    break;
            }
        }
    }
