    using (MemoryStream ms = new MemoryStream())
    {
      picturePictureEdit.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        c.Picture = ms.ToArray();
    }
