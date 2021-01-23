    public async Task Post()
    {
        var multipart = await Request.Content.ReadAsMultipartAsync();
    
        foreach (var content in multipart.Contents)
        {
            var products = await content.ReadAsAsync<IEnumerable<Product>>();
        }
    }
