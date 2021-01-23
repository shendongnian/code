    CloudBlockBlob blockBlob = new CloudBlockBlob();
    using (var fileStream = System.IO.File.OpenRead(path + "/" + up.GetName().ToString()))
    {
          blockBlob.UploadFromStream(fileStream);
    }
    string URL = blockBlob.Uri.OriginalString;
