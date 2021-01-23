      using (MemoryStream ms = new MemoryStream())
      {
          image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
          var binary = new System.Data.Linq.Binary(ms.GetBuffer());
      }
