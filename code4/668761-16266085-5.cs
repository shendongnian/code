    public class StatusesController : ApiController
    {
        [HttpPost]
        public bool Post([FromBody]string value)
        {
            return CheckStatus(value);
        }
        private bool CheckStatus(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD"; //only retrieve headers
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                response = (HttpWebResponse) e.Response;   
            }
            var responseCode = (int)response.StatusCode;
            return responseCode < 400; //erroneus response codes starts at 400
        }
    }
