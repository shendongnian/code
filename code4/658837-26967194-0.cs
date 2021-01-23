    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                string urlDemo = "http://en.wikipedia.org/wiki/Main_Page";
                // Create a request for the URL. 
                WebRequest request = WebRequest.Create(urlDemo);
                // If required by the server, set the proxy credentials.
                request.Proxy.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                Console.ReadLine();
                // Clean up the streams and the response.
                reader.Close();
                response.Close();
               
            }
        }
    }
