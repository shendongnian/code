    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
           
            request = WebRequest.Create("https://myipaddress/api/admin/configuration/v1/conference/1/");
             
            request.Credentials = new NetworkCredential("admin", "admin123");
            // Create POST data and convert it to a byte array.
            request.Method = "GET";          
           
                    // Set the ContentType property of the WebRequest.
            request.ContentType = "application/json; charset=utf-8";          
   
            
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var obj = js.Deserialize<dynamic>(responseFromServer);
            Label1.Text = obj["name"];
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();
