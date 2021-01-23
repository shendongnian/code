    [HttpPost]
    [Route("api/dashboard/saveThumbnail")]
    public HttpResponseMessage SaveThumbnail()
    {
        //string base64string = "iVBORw0KGgoAAAANSUhEUgAAAHgAAAA3CAMAAADwtH5ZAAADAFBMVEX//////P///v/+///3/f3//f+zoJL3///15/SK";
        var httpRequest = HttpContext.Current.Request;
        string base64string =  httpRequest["Thumbnail"]; // get from request
        byte[] blob = Convert.FromBase64String(base64string);
        var fileExt= GetFileExtension(base64string );
        var filePath = string.Format("{0}\{1}.{2}", @"C:\Picture", "mypicture", fileExt);
        File.WriteAllBytes(filePath, blob);
    }
