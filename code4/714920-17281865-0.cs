    protected ActionResult InlineFile(byte[] content, string contentType, string fileDownloadName)
        {
            Response.AppendHeader("Content-Disposition", string.Concat("inline; filename=\"", fileDownloadName, "\""));
            return File(content, contentType);
        }
