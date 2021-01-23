    using (MagickImage magickImage = new MagickImage())
    {
      using (var magickStream = new MemoryStream())
      {
        magickImage.Read(@"gdi_err.jpg");
        magickImage.Strip();
        magickImage.Write(magickStream);
        magickStream.Position = 0;
        
        // This part is just here to demonstrate that saving the image works.
        // You don't need it because magickStream already contains the data you want.
        using (Image image = Image.FromStream(magickStream))
        {
          using (var ms = new MemoryStream())
          {
            image.Save(ms, ImageFormat.Jpeg);
          }
        }
      }
    }
