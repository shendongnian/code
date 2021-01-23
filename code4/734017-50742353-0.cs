    public ActionResult DownloadFile(String FileUniqueName)
        {
            var rootPath = Server.MapPath("~/UploadedFiles");
            var fileFullPath = System.IO.Path.Combine(rootPath,FileUniqueName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fileFullPath);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "MyDownloadFile");
                
        }
