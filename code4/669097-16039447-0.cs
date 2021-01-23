    namespace ConsoleApplication8
    {
        class Program
        {
            static void Main(string[] args)
            {
                string post2;
                for (int i = 111; i < 222; i++)
                {
                    post2 = i.ToString();
                    System.Net.HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://google.com");
                    request.Method = "POST";
                    request.KeepAlive = true;
                    request.UserAgent = "Mozilla/5.0 (Windows NT 5.1; rv:19.0) Gecko/20100101 Firefox/19.0";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    request.ServicePoint.Expect100Continue = false;
                    string postData = post2;
                    byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                    request.ContentLength = byteArray.Length;
                    // You need to close the request stream when you're done writing to it.
                    using(Stream dataStream = request.GetRequestStream())
                    {
                        dataStream.Write(byteArray, 0, byteArray.Length);         
                        Console.WriteLine(post2);
                    }
                    // Even if you don't need the response, you still need to close it.
                    request.GetResponse().Close();
                }                              
            }
        }
    }
