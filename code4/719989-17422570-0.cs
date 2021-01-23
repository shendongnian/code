    byte[,] Texture8 = new byte[,]
    {
        { 000, 000, 255 },
        { 000, 255, 255 },
        { 000, 255, 000 },
        { 255, 255, 000 },
        { 255, 000, 000 },
        { 000, 000, 000 },
        { 000, 000, 000 },
        { 000, 000, 000 }
    };
    // ...
    GL.TexImage1D(TextureTarget.Texture1D, 0, 
                  PixelInternalFormat.Three, /*with*/8, 0, 
                  PixelFormat.Rgb, 
                  PixelType.UnsignedByte, Texture8);
