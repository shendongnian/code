    public HttpResponseMessage Get()
    {
        var content = new MultipartContent();
        var ids = new List<int>() { 1, 2 };
        var objectContent = new ObjectContent<List<int>>(ids, new System.Net.Http.Formatting.JsonMediaTypeFormatter());
        content.Add(objectContent);
        var file1Content = new StreamContent(new FileStream(@"c:\temp\desert.jpg", FileMode.Open));
        file1Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("image/jpeg");
        content.Add(file1Content);
        var file2Content = new StreamContent(new FileStream(@"c:\temp\test.txt", FileMode.Open));
        file2Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("text/plain");
        content.Add(file2Content);
        var response = new HttpResponseMessage();
        response.Content = content;
        return response;
    }
