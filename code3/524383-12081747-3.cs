    Animal a = new Animal();
    a.Message = "öçşistltl";
    string postDataString = JsonConvert.SerializeObject(a);        
    string URL = "http://localhost/Values/DoSomething";
    string postDataString = JsonConvert.SerializeObject(a);
    using (WebClient client = new WebClient())
    {
        client.Encoding = Encoding.UTF8;
        client.UploadStringCompleted += client_UploadStringCompleted;
        client.Headers["Content-Type"] = "application/json; charset=utf-8";
        client.UploadDataAsync(new Uri(URI), "POST", Encoding.UTF8.GetBytes(postDataString));
    }
