    private void CopyStream(Stream input, Stream output) {
      byte[] buffer = new byte[32768];
      int read;
      while ((read = input.Read(buffer, 0, buffer.Length)) > 0) {
        output.Write(buffer, 0, read);
      }
    }
    private string GetContentType(string serverContentType, string imageUrl) {
      if (string.IsNullOrEmpty(imageUrl))
        throw new ArgumentNullException("imageUrl");
      ImageMimeType mimeType;
      if (!string.IsNullOrEmpty(serverContentType)) {
        serverContentType = serverContentType.ToLowerInvariant();
        mimeType = ImageMimeType.MimeTypes.Where(m => m.MimeType == serverContentType).FirstOrDefault();
        if (mimeType != null) {
          return mimeType.MimeType;
        }
      }
      string extension = Path.GetExtension(imageUrl).ToLowerInvariant();
      mimeType = ImageMimeType.MimeTypes.Where(m => m.FileExtension == extension).FirstOrDefault();
      if (mimeType != null) {
        return mimeType.MimeType;
      }
      return "application/octet-stream";
    }
    private class EmailImage {
      public string Url { get; set; }
      public string MailID { get; set; }
    }
    private class ImageMimeType {
      public string FileExtension { get; private set; }
      public string MimeType { get; private set; }
      public static List<ImageMimeType> MimeTypes = new List<ImageMimeType> {
        new ImageMimeType { FileExtension = ".png", MimeType = "image/png"},
        new ImageMimeType { FileExtension = ".jpe", MimeType = "image/jpeg" },
        new ImageMimeType { FileExtension = ".jpeg", MimeType = "image/jpeg" },
        new ImageMimeType { FileExtension = ".jpg", MimeType = "image/jpeg" },
        new ImageMimeType { FileExtension = ".gif", MimeType = "image/gif" },
        new ImageMimeType { FileExtension = ".bmp", MimeType = "image/bmp" }
      };
    }
    
