    HttpWebRequest _request;
       
    private void doGetRequest()
      _request = WebRequestCreator.ClientHttp.Create(new Uri("http://localhost/getDummy")) as HttpWebRequest;
            var webTask = Task.Factory.FromAsync<WebResponse>
                (_request.BeginGetResponse, _request.EndGetResponse, null)
              .ContinueWith(
                task =>
                {
                    var response = (HttpWebResponse)task.Result;
                    // The reason I use HttpRequest, not WebRequest, to get statuscode.
                    if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                    {
                         //Do Stuff
                    }
                });
