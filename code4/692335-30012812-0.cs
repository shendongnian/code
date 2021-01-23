    public Size GetSize(byte[] bytes)
    {
       using (var stream = new MemoryStream(bytes))
       {
          var image = System.Drawing.Image.FromStream(stream);
          return image.Size;
       }
    }
