    [HttpPost]
    public ActionResult FileUpload(string qqfile)
    {
        try
        {
            var stream = Request.InputStream;
            var filename = Path.GetFileName(qqfile);
            // TODO: not sure about the content type. Check
            // with the documentation how is the content type 
            // for the file transmitted in the case of HTML5 File API
            var contentType = Request.ContentType;
            if (string.IsNullOrEmpty(qqfile))
            {
                // IE
                var postedFile = Request.Files[0];
                stream = postedFile.InputStream;
                filename = Path.GetFileName(postedFile.FileName);
                contentType = postedFile.ContentType;
            }
            var contentLength = stream.Length;
            var newAttachment = new App_MessageAttachment
            {
                FileName = filename,
                FilteContentType = contentType,
                MessageId = 4,
                FileData = new byte[contentLength]
            };
            stream.Read(newAttachment.FileData, 0, contentLength);
            db.App_MessageAttachments.InsertOnSubmit(newAttachment);
            db.SubmitChanges();
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
        return Json(new { success = true }, "text/html");
    }
