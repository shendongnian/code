    private byte[] LoadImage(string szPathname)
      {
         try
         {
            Bitmap image = new Bitmap(szPathname, true);
            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Bmp);
            return ms.ToArray();
         }catch (Exception){...}
         return null;
      }
