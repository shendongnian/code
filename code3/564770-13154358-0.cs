    public Color GetPixel(int x, int y)
    {
    
        int color = 0;
    
        if (x < 0 || x >= Width)
        {
            throw new ArgumentOutOfRangeException("x", SR.GetString(SR.ValidRangeX));
        }
    
        if (y < 0 || y >= Height)
        {
            throw new ArgumentOutOfRangeException("y", SR.GetString(SR.ValidRangeY));
        }
    
        int status = SafeNativeMethods.Gdip.GdipBitmapGetPixel(new HandleRef(this, nativeImage), x, y, out color);
    
        if (status != SafeNativeMethods.Gdip.Ok)
            throw SafeNativeMethods.Gdip.StatusException(status);
    
        return Color.FromArgb(color);
    }
