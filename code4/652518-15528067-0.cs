    Bitmap bitmap = new Bitmap("blah");
    Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
    BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
    ... whatever you want ...
    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, 4, bitmap.Width, bitmap.Height, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, bitmap.Scan0);
    
    if(bitmap != null) {
        bitmap.UnlockBits(bitmapData);
        bitmap.Dispose();
    }
