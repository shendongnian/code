    using (var client = new WebClient())
    {
        var values = new NameValueCollection
        {
            { "key1", "value1" },
            { "key2", "value2" },
        };
        byte[] result = client.UploadValues("http://192.168.220.12:5000", values);
        string resultStr = Encoding.Default.GetString(result);
        ...
    }
