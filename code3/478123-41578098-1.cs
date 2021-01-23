    using (var ms = new MemoryStream())
    {    
      using (var bitmap = new Bitmap(newImage))
      {
        bImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        var SigBase64= Convert.ToBase64String(ms.GetBuffer()); //Get Base64
      }
    }
