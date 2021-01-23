    private System.Drawing.Bitmap BitmapFromWriteableBitmap(WriteableBitmap writeBmp)
    {
      System.Drawing.Bitmap bmp;
      using (MemoryStream outStream = new MemoryStream())
      {
        BitmapEncoder enc = new BmpBitmapEncoder();
        enc.Frames.Add(BitmapFrame.Create((BitmapSource)writeBmp));
        enc.Save(outStream);
        bitmap = new System.Drawing.Bitmap(outStream);
      }
      return bmp;
    }
    
