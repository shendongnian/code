    [HttpPost]
    public async Task<IHttpActionResult> PostFiles()
    {
        return Ok
        (
            await Task.WhenAll
            (
                (await Request.Content.ReadAsMultipartAsync())
                
                .Contents
                .Select(async content => await ProcessSingleContentAsync(content))  
            )
        );
    }
    
    private async Task<string> ProcessSingleContentAsync(HttpContent content)
    {
        return SomeLogic(await content.ReadAsByteArrayAsync());
    }
