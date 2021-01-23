    [HttpPost]
    public IHttpActionResult PostFiles()
    {
        return Ok
        (
            Request.Content.ReadAsMultipartAsync().Result
        
            .Contents
            .Select(content => ProcessSingleContent(content))
        );
    }
    
    private string ProcessSingleContent(HttpContent content)
    {
        return SomeLogic(content.ReadAsByteArrayAsync().Result);
    }
