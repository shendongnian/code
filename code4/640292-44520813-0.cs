    public List<string> UploadFiles(HttpFileCollection fileCollection)
        {
            var uploadsDirectoryPath = HttpContext.Current.Server.MapPath("~/Uploads");
            if (!Directory.Exists(uploadsDirectoryPath))
                Directory.CreateDirectory(uploadsDirectoryPath);
            var filePaths = new List<string>();
            for (var index = 0; index < fileCollection.Count; index++)
            {
                var path = Path.Combine(uploadsDirectoryPath, Guid.NewGuid().ToString());
                fileCollection[index].SaveAs(path);
                filePaths.Add(path);
            }
            return filePaths;
        }
