    HttpRequestMessage<RequestType> request = 
         new HttpRequestMessage<RequestType>(
           new RequestType("third-party-vendor-action"),
           MediaTypeHeaderValue.Parse("application/xml"));
     request.Headers.Authorization = new AuthenticationHeaderValue("Basic", 
           Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "username", "password"))));
     
     request.Method = HttpMethod.Post;
     request.RequestUri = Uri;
     var task = client.SendAsync(request);
     ResponseType response = task.ContinueWith(
        t =>
        {
           return t.Result.Content.ReadAsAsync<ResponseType>();
        }).Unwrap().Result;
