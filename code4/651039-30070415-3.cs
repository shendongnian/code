    public static ImageFromBased64String(string based64Image, string path)
    {
      Image image = null;
      var bytes = Convert.FromBased64String(based64String);
      using (var fileStream = new FileStream(path, FileMode.Create))
      {
        fileStream.Write(bytes, 0, bytes.Length);
        fileStream.Flush();
        image = Image.FromStream(fileStream, true);
        return image;
      }
    }
    
