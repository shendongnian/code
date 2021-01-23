    async public Task<HttpResponseMessage> UploadImage(string url, byte[] ImageData)
    {
        var requestContent = new MultipartFormDataContent(); 
        //    here you can specify boundary if you need---^
        var imageContent = new ByteArrayContent(ImageData);
        imageContent.Headers.ContentType = 
            MediaTypeHeaderValue.Parse("image/jpeg");
        requestContent.Add(imageContent, "image", "image.jpg");
        return await client.PostAsync(url, requestContent);
    }
