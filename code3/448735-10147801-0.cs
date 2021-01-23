    public static class WebFetcher
    {
        public WebResponse FetchFromUrl(Uri uri)
        {
            try
            {
                var request = WebRequest.Create(new Uri("MyUrl")) as HttpWebRequest;
                return request.GetResponse();
            }
            catch (NotSupportedException ex)
            {
                //you could customize the error messages to be more suitable for your
                //application, or leaving room for future error handling
                throw new WebFetcherException(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                throw new WebFetcherException(ex.Message, ex);
            }
            catch (SecurityException ex)
            {
                throw new WebFetcherException(ex.Message, ex);
            }
            catch (ProtocolViolationException ex)
            {
                throw new WebFetcherException(ex.Message, ex);
            }
            catch (WebException ex)
            {
                throw new WebFetcherException(ex.Message, ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new WebFetcherException(ex.Message, ex);
            }
        }
        public class WebFetcherException : Exception
        {
            public WebFetcherException(string message, Exception inner)
                : base(message, inner)
            { }
        }
    }
