    public async Task DefLoginAsync()
    {
        postData = "My Data To Post";
        var url = new Uri("Url To Post to", UriKind.Absolute);
        webRequest = WebRequest.Create(url);
        webRequest.Method = "POST";
        webRequest.ContentType = "text/xml";
        using (Stream postStream = await webRequest.GetRequestStreamAsync())
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            await postStream.WriteAsync(byteArray, 0, byteArray.Length);
            awair postStream.FlushAsync();
        }
        try
        {
            string Response;
            using (var response = (HttpWebResponse)await webRequest.GetResponseAsync());
            using (Stream streamResponse = response.GetResponseStream())
            using (StreamReader streamReader = new StreamReader(streamResponse))
            {
                Response = await streamReader.ReadToEndAsync();
            }
            if (Response == "")
            {
                //show some error msg to the user        
                Debug.WriteLine("ERROR");
            }
            else
            {
                //Your response will be available in "Response" 
                Debug.WriteLine(Response);
            }
        }
        catch (WebException)
        {
            //error    
        }
    }
