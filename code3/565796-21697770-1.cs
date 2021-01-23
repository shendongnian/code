    public bool ResizeImage(string OriginalFilepath, string NewFilepath)
    {
      Bitmap original = (Bitmap)Image.FromFile(OriginalFilepath);
      Bitmap resized = new Bitmap(original, new Size(Width,Height));
      resized.Save(NewFilepath.png);      
    }
