     string boundary = "AaB03x";
        
        try
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";                
            request.ContentType = "multipart/form-data;boundary="+boundary;
    
            using (var requestStream = request.GetRequestStream())
            using (var writer = new StreamWriter(requestStream))
            {
                writer.WriteLine("--"+boundary);
                writer.WriteLine( "Content-Disposition: form-data; name=\"files\"; filename=\"file1.txt\"");
                 writer.WriteLine("Content-Type: text/plain
        ");
                writer.WriteLine("example");        
                writer.WriteLine("--"boundary + "--");
                writer.Flush();
            }
            string responseData = string.Empty;
            using (var response = request.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                responseData=reader.ReadToEnd();
            }
