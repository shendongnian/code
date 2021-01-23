    public Bitmap Draw()
    {
         var bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
         using (var graphics = Graphics.FromBitmap(bitmap)
         {
              // First: Setup rendering settings like SmoothingMode, TextRenderingHint, ...
              // Layer specific drawing code goes here...
         }
         return bitmap;
    }
