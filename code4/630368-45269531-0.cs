    response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline")
    {
    	FileName = image.OriginalFileName,
    	Size = image.ImageData.Length
    };
