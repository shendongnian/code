    [HttpPost, Route("api/upload")]
    public async Task<IHttpActionResult> Upload()
    {
        if (!Request.Content.IsMimeMultipartContent())
             throw new Exception(); // divided by zero
        var provider = new MultipartMemoryStreamProvider();
        await Request.Content.ReadAsMultipartAsync(provider);
        foreach (var file in provider.Contents)
        {
            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
            var buffer = await file.ReadAsByteArrayAsync();
            //Do whatever you want with filename and its binaray data.
        }
        return Ok();
    }
