     /// <summary>
    /// Renders only part of the visual and returns byte[] array
    /// which holds only black/white information.
    /// </summary>
    /// <param name="oVisual"></param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns>black/white pixel information. one pixel=one bit. 1=white, 0=black</returns>
    public static byte[] RenderPartially(Visual oVisual, 
        int x, int y, double width, double height)
    {
        int nWidth = (int)Math.Ceiling(width);
        int nHeight = (int)Math.Ceiling(height);
        RenderTargetBitmap oTargetBitmap = new RenderTargetBitmap(
            nWidth,
            nHeight,
            96,
            96,
            PixelFormats.Pbgra32
        );
        DrawingVisual oDrawingVisual = new DrawingVisual();
        using (DrawingContext oDrawingContext = oDrawingVisual.RenderOpen())
        {
            VisualBrush oVisualBrush = new VisualBrush(oVisual);
            oDrawingContext.DrawRectangle(
                oVisualBrush,
                null,
                new Rect(
                    new Point(x, y),
                    new Size(nWidth, nHeight)
                )
            );
            oDrawingContext.Close();
            oTargetBitmap.Render(oDrawingVisual);
        }
        //Pbgra32 == 32 bits ber pixel?!(4bytes)
        // Calculate stride of source and copy it over into new array.
        int bytesPerPixel = oTargetBitmap.Format.BitsPerPixel / 8;
        int stride = oTargetBitmap.PixelWidth * bytesPerPixel;
        byte[] data = new byte[stride * oTargetBitmap.PixelHeight];
        oTargetBitmap.CopyPixels(data, stride, 0);
        //assume pixels in byte[] are stored as PBGRA32 which means that 4 bytes form single PIXEL.
        //so the layout is like:
        // R1, G1, B1, A1,  R2, G2, B2, A2,  R3, G3, B3, A3, and so on.
        
        byte [] bitBufferBlackWhite = new byte[oTargetBitmap.PixelWidth
            * oTargetBitmap.PixelHeight / bytesPerPixel];
        for(int row = 0; row < oTargetBitmap.PixelHeight; row++)
        {
            for(int col = 0; col < oTargetBitmap.PixelWidth; col++)
            {
                //calculate concrete pixel from PBGRA32
                int index = stride * row + bytesPerPixel * col;
                int r = data[index];
                int g = data[index + 1];
                int b = data[index + 2];
                int transparency = data[index + 3];
                //determine whenever pixel is black or white.
                //note that I dont know the exact process how one converts
                //from PBGRA32 to BlackWhite format. But you should get the idea.
                bool isBlack = r + g + b + transparency == 0;
                //calculate target index and USE bitwise operators in order to
                //set right bits.
            }
        }
        
        return bitBufferBlackWhite;
    }
