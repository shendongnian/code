protected override Task<HttpResponseMessage> SendAsync(
          HttpRequestMessage request,
          CancellationToken cancellationToken)
      {                    
          Stream stream = new MemoryStream();
          request.Content.ReadAsStreamAsync().Result.CopyTo(stream);
          stream.Seek(0,SeekOrigin.Begin);
          // copy off the content "for later"
          string query = new StreamReader(stream).ReadToEnd();
          stream.Seek(0,SeekOrigin.Begin);
          
          // if further processing depends on content type
          // go ahead and grab current value
          var contentType = request.Content.Headers.ContentType;
          request.Content = new StreamContent(stream);
          request.Content.Headers.ContentType = contentType;
          return base.SendAsync(request, cancellationToken);
     }
