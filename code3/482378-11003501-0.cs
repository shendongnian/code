    //Creating client instance and set the credentials
    var client = new WebClient();
    client.Credentials = new NetworkCredential(...);
    
    // using GET Request:
    var data = client.DownloadData("http://myurl/...");
    
    // Using PUT
    var data = Encoding.UTF8.GetBytes("My text goes here!");
    client.UploadData("http://myurl/...", "PUT", data);
    
    // Using POST
    var data = new NameValueCollection();
    data.Add("Field1", "value1");
    data.Add("Field2", "value2");
    client.UploadValues("http://myurl/...", "POST", data);
