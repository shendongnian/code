    using (var client = new WebClient())
    {
        var values = new NameValueCollection
        {
            { "param1", "value1" },
            { "param2", "value2" },
            { "param3", "value3" },
            { "param4", "value4" },
        };
        byte[] result = client.UploadValues(values);
    }
