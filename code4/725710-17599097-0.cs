    foreach (MagickImage image in images)
    {
      using (Bitmap bmp = image.ToBitmap())
      {
        tessnet2.Tesseract tessocr = new tessnet2.Tesseract();
        // etc...
      }
    }
