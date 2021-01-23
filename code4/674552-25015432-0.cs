    private static WebResponse CreateWebResponse(HttpStatusCode httpStatus, MemoryStream responseObject)
    {
      TcpListener l = new TcpListener(IPAddress.Loopback, 0);
      l.Start();
      int port = ((IPEndPoint)l.LocalEndpoint).Port;
      l.Stop();
      // Create a listener.
      string prefix = "http://localhost:" + port + "/";
      HttpListener listener = new HttpListener();
      listener.Prefixes.Add(prefix);
      listener.Start();
      try
      {
        listener.BeginGetContext((ar) =>
        {
          HttpListenerContext context = listener.EndGetContext(ar);
          HttpListenerRequest request = context.Request;
          // Obtain a response object.
          HttpListenerResponse response = context.Response;
          response.StatusCode = (int)httpStatus;
          // Construct a response.
          if (responseObject != null)
          {
            byte[] buffer = responseObject.ToArray();
            // Get a response stream and write the response to it.
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
          }
          response.Close();
        }, null);
        WebClient client = new WebClient();
        try
        {
          WebRequest request = WebRequest.Create(prefix);
          request.Timeout = 30000;
          return request.GetResponse();
        }
        catch (WebException e)
        {
          return e.Response;
        }
      }
      finally
      {
        listener.Stop();
      }
      return null;
    }
