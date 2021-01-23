        class Program
            {
                static void Main(string[] args)
                {
                    string uriString = "http://www.remotesite.com/login.cfm";
                    // Create a new WebClient instance.
                    WebClientX myWebClient = new WebClientX();
                    // Create a new NameValueCollection instance to hold some custom parameters to be posted to the URL.
                    NameValueCollection myNameValueCollection = new NameValueCollection();
                    // Add necessary parameter/value pairs to the name/value container.
                    myNameValueCollection.Add("userid", "myname");
                    myNameValueCollection.Add("mypassword", "mypassword");
                    Console.WriteLine("\nUploading to {0} ...", uriString);
                    // 'The Upload(String,NameValueCollection)' implicitly method sets HTTP POST as the request method.            
                    byte[] responseArray = myWebClient.UploadValues(uriString, myNameValueCollection);
                    // Decode and display the response.
                    Console.WriteLine("\nResponse received was :\n{0}", Encoding.ASCII.GetString(responseArray));
                    Console.WriteLine("\n\n\n pausing...");
                    Console.ReadKey();
                    // Go to 2nd page on the site to get additional data
                    Stream myStream = myWebClient.OpenRead("https://www.remotesite.com/status_results.cfm?t=8&prog=d");
                    Console.WriteLine("\nDisplaying Data :\n");
                    StreamReader sr = new StreamReader(myStream);
                    StringBuilder sb = new StringBuilder();
                    using (StreamReader reader = new StreamReader(myStream, System.Text.Encoding.UTF8))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            sb.Append(line + "\r\n");
                        }
                    }
                    using (StreamWriter outfile = new StreamWriter(@"Logfile1.txt"))
                    {
                        outfile.Write(sb.ToString());
                    }
                    Console.WriteLine(sb.ToString());
                    Console.WriteLine("\n\n\n pausing...");
                    Console.ReadKey();
                }
            }
            public class WebClientX : WebClient
            {
                public CookieContainer cookies = new CookieContainer();
                protected override WebRequest GetWebRequest(Uri location)
                // public override WebRequest GetWebRequest(Uri location)
                {
                    WebRequest req = base.GetWebRequest(location);
                    if (req is HttpWebRequest)
                        (req as HttpWebRequest).CookieContainer = cookies;
                    return req;
                }
                protected override WebResponse GetWebResponse(WebRequest request)
                {
                    WebResponse res = base.GetWebResponse(request);
                    if (res is HttpWebResponse)
                        cookies.Add((res as HttpWebResponse).Cookies);
                    return res;
                }
            }
