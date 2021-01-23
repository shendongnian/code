    using (var client = new WebClient())
    {
        var data = new NameValueCollection
        {
            { "image", imageBase64String }
        };
        var result = client.UploadValues(ip, data);
        Console.WriteLine(Encoding.Default.GetString(result));
    }
