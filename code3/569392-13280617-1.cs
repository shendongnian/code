    using System.Text;
    using System.Net;
    using System.IO;
    using System.Diagnostics;
    namespace HttpsRequest
    {
        public static class Program
        {
            public static void Main(string[] args)
            {
                var cookieContainer = new CookieContainer();
                var loginRequest = WebRequest.CreateHttp("https://your.url.net/login");
                loginRequest.CookieContainer = cookieContainer;
                var response = loginRequest.Post("Login=foo&Password=bar");
                Debug.Assert(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent);
                var homeRequest = WebRequest.CreateHttp("https://your.url.net/home");
                homeRequest.CookieContainer = cookieContainer;
                Debug.Assert(response.StatusCode == HttpStatusCode.OK);
                homeRequest.GetResponse().Body();
            }
        
            internal static HttpWebResponse Post(this HttpWebRequest request, string data)
            {
                try
                {
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    var encoding = new ASCIIEncoding();
                    var dataAsBytes = encoding.GetBytes(data);
                    request.ContentLength = dataAsBytes.Length;
                    var stream = request.GetRequestStream();
                    stream.Write(dataAsBytes, 0, dataAsBytes.Length);
                    stream.Close();
                    return (HttpWebResponse)request.GetResponse();
                }
                catch (WebException we)
                {
                    return (HttpWebResponse)we.Response;
                }
            }
        
            internal static string Body(this WebResponse response)
            {
                var stream = response.GetResponseStream();
                using (var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8")))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
