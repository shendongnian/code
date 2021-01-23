    //Start server
    var m = new MyServer();
    m.Start();
    Task.Delay(1000);
    //Call server method
    using (var wc = new WebClient())
    {
        wc.Headers[HttpRequestHeader.ContentType] = "application/json";
        var obj = new { companyName = "cocaCola",imsi="3324" };
        string response = wc.UploadString("http://localhost/Test/SaveUsersCode", new JavaScriptSerializer().Serialize(obj));
        Console.WriteLine(response);
    }
