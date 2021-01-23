    public async Task<HttpResponseMessage> PostUpload()
    {
        var provider = new MultipartFileStreamProvider(Path.GetTempPath());
        
        // Read the form data.
        await Request.Content.ReadAsMultipartAsync(provider);
        
        // do the rest the same     
    }
