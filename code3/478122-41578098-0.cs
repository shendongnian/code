    using (var bitmap = new Bitmap(newImage))
     {
      System.IO.MemoryStream ms = new System.IO.MemoryStream();
      bImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
      var SigBase64= Convert.ToBase64String(ms.GetBuffer()); //Get Base64
     }
