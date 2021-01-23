    var request = WebRequest.Create("http://example.com/profile/190/updateprofile");
    request.Method = "PUT";
    request.ContentType = "application/json; charset=utf-8";
    using (var writer = new StreamWriter(request.GetRequestStream()))
    {
        var serializer = new JavaScriptSerializer();
        var payload = serializer.Serialize(new 
        {
            UserId = "9769595975",
            Passold = "qwert1",
            Passnew = "qwert2"
        });
        writer.Write(payload);
    }
    using (var response = request.GetResponse())
    using (var reader = new StreamReader(response.GetResponseStream()))
    {
        string result = reader.ReadToEnd();
        // do something with the results
    }
