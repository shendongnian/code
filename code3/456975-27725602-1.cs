    [Route("api/myfileupload")]        
    [HttpPost]
    public string MyFileUpload()
    {
        var request = HttpContext.Current.Request;
        var filePath = "C:\\temp\\" + request.Headers["filename"];
        using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
        {
            request.InputStream.CopyTo(fs);
        }
        return "uploaded";
    }
