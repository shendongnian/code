    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using Newtonsoft.Json;
    
    namespace Examples.System.Net
    {
        public class WebRequestGetExample
        {
            public static void Main ()
            {
                // Create a request for the URL. 
                WebRequest request = WebRequest.Create (
                  "http://api.geonames.org/citiesJSON?north=44.1&south=-9.9&east=-22.4&west=55.2&lang=de&username=demo");
                // Get the response.
                WebResponse response = request.GetResponse ();
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream ();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader (dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd ();
                // Parse JSON 
                JObject o = JObject.Parse(responseFromServer);
                JArray status= (JArray)o["status"];
                string message = (string)status["message"];
                // Clean up the streams and the response.
                reader.Close ();
                response.Close ();
            }
        }
    }
    
