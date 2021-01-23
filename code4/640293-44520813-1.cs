    if (!Request.Content.IsMimeMultipartContent())
    {
        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
    }
    var filePaths = _formsService.UploadFiles(HttpContext.Current.Request.Files);
