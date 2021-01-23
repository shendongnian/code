    using (MemoryStream ms = new MemoryStream(File.ReadAllBytes(realPath)))
      {
       using (Image img = Image.FromStream(ms))
        {
         //code here
         img.Save(realPath, System.Drawing.Imaging.ImageFormat.Png);
         }
      }
