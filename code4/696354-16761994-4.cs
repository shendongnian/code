    public void SetPixel(WriteableBitmap wb, int x, int y, Color color)
    {
        var pixelRect = new Int32Rect(x, y, 1, 1);
        var pixelBuffer = new byte[4];
        wb.CopyPixels(pixelRect, pixelBuffer, 4, 0);
        pixelBuffer[0] = (byte)(pixelBuffer[0] * (1F - color.ScA) + color.B * color.ScA);
        pixelBuffer[1] = (byte)(pixelBuffer[1] * (1F - color.ScA) + color.G * color.ScA);
        pixelBuffer[2] = (byte)(pixelBuffer[2] * (1F - color.ScA) + color.R * color.ScA);
        wb.WritePixels(pixelRect, pixelBuffer, 4, 0);
    }
