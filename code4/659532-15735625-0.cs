    var client = new HttpClient();
    client.DefaultRequestHeaders.Add("X-Auth_User", "your_username");
    client.DefaultRequestHeaders.Add("X-Auth-Key", "your_api_key");
    
     client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("image/pjpeg"));
    var bytes = File.ReadAllBytes(imagePath);
    var ms = new MemoryStream(bytes);
    
     client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("image/pjpeg"));
     var content = new StreamContent(ms);
    
    
     var response = client.PutAsync("YOUR_RACKSPACE_URI", content);
