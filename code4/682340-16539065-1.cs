    // Create the REST URL. 
    string requestUrl = @"http://localhost:2949/fileupload?public_id=id&tags=tags";
    //file to upload make sure it exist
    string filename = @"C:\temp\ImageUploaderService\vega.jpg";
    
    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
    request.Method = "POST";
    //request.ContentType = "text/plain";
    request.ContentType = "application/json; charset=utf-8";
    byte[] fileToSend = File.ReadAllBytes(filename);
    request.ContentLength = fileToSend.Length;
    using (Stream requestStream = request.GetRequestStream())
     {
     // Send the file as body request. 
     requestStream.Write(fileToSend, 0, fileToSend.Length);
     requestStream.Close();
    }
    
     using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
     {
        Console.WriteLine("HTTP/{0} {1} {2}", response.ProtocolVersion,     (int)response.StatusCode, response.StatusDescription);
        string text;
         using (var sr = new StreamReader(response.GetResponseStream()))
                        {
                            text = sr.ReadToEnd();
                        }
    
                        dynamic testObj = Newtonsoft.Json.JsonConvert.DeserializeObject(text);
    
                        Console.WriteLine(string.Format("response url is {0}", testObj.url));
                    }
