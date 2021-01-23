    public SenHttpMockResponse(HttpListenerContext context)
    {
       HttpListenerResponse response = context.Response;
       response.Headers.Add("Content-type", @"application/json");
       JObject message = JObject.Parse(@"{'SomeParameterName':'ParameterValue'}");
       StreamWriter writer = new StreamWriter(response.OutputStream);
       writer.Write(message);
       writer.Close();
    }
