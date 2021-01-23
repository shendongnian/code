    var vm = new { k = "1", a = "2", c = "3", v=  "4" };
    using (var client = new WebClient())
    {
       var dataString = JsonConvert.SerializeObject(vm);
       client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
       client.UploadString(new Uri("http://www.contoso.com/1.0/service/action"), "POST", dataString);
       client.UploadStringCompleted += InsertItemCompleted;
    }
    static void InsertItemCompleted(object sender, UploadStringCompletedEventArgs e)
    {
           //...
    }
