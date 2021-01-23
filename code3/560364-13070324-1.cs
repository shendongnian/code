    public class TestService : ITestService
    {
        public Stream Tester()
        {
            NameValueCollection queryStringCol = WebOperationContext.Current.IncomingRequest.UriTemplateMatch.QueryParameters;
            if (queryStringCol != null && queryStringCol.Count > 0)
            {
                string parameters = string.Empty;
                for (int i = 0; i < queryStringCol.Count; i++)
                {
                    parameters += queryStringCol[i] + "\n";
                }
                return new MemoryStream(Encoding.UTF8.GetBytes(parameters));
            }
            else
                return new MemoryStream(Encoding.UTF8.GetBytes("Hello Jersey!"));
        }
    }
