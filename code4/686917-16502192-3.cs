    public class NoKeepAlivesWebClient : WebClient
    {
        public override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                ((HttpWebRequest)request).KeepAlive = false;
            }
            return request;
        }
    }
