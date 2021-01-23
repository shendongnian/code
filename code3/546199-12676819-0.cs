    var http = new HttpClient();
    http.Request.Accept = HttpContentTypes.ApplicationJson;
    var response = http.Get("url");
    var body = response.DynamicBody;
    Console.WriteLine("Name {0}", body.AppName.Description);
    Console.WriteLine("Name {0}", body.AppName.Value);
