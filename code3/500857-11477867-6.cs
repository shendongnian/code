    byte[] image = ... go and fetch the image that you want to upload
    using (var stream = new MemoryStream(image))
    using (var client = new WebClient())
    {
        var files = new[]
        {
            new UploadFile
            {
                Name = "image",
                Filename = "test.jpg",
                ContentType = "image/jpg",
                Stream = stream
            }
        };
        var result = client.UploadFiles("http://localhost:6830/uploadimage.ashx", files, new NameValueCollection());
        Console.WriteLine(Encoding.Default.GetString(result));
    }
