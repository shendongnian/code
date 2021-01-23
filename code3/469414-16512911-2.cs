    var frame = capture.QueryFrame();
    frame = frame.Resize(256, 256, Emgu.CV.CvEnum.INTER.CV_INTER_NN);
    Bitmap Bitmap = frame.Bitmap;
    BitmapData bitmapData = Bitmap.LockBits(new Rectangle(0, 0, Bitmap.Width, Bitmap.Height),
        ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
    gl.BindTexture(OpenGL.GL_TEXTURE_2D, textures[0]);
    gl.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, OpenGL.GL_RGBA, Bitmap.Width, Bitmap.Height, 0, OpenGL.GL_BGR, OpenGL.GL_UNSIGNED_BYTE, bitmapData.Scan0);
    gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR); // Required for TexImage2D
    gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR); // Required for TexImage2D
