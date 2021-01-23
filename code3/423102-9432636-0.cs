    var values = new NameValueCollection();
    values.Add("param1", "value1");
    values.Add("param2", "value2");
    using (var client = new WebClient())
    {
        // uses POST
        client.UploadValues(url, values);  
        // See Also 'UploadString'
    }
