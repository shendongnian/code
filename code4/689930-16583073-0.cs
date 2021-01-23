            WriteableBitmap wb = new WriteableBitmap(this.canvas1,null);
            Stream sm = GetBase64Image(wb);       
          public static Stream GetBase64Image(WriteableBitmap bitmap)
            {
                int width = bitmap.PixelWidth;
                int height = bitmap.PixelHeight;
                int bands = 3;
                byte[][,] raster = new byte[bands][,];
    
                for (int i = 0; i < bands; i++)
                {
                    raster[i] = new byte[width, height];
                }
    
                for (int row = 0; row < height; row++)
                {
                    for (int column = 0; column < width; column++)
                    {
                        int pixel = bitmap.Pixels[width * row + column];
                        raster[0][column, row] = (byte)(pixel >> 16);
                        raster[1][column, row] = (byte)(pixel >> 8);
                        raster[2][column, row] = (byte)pixel;
                    }
                }
    
                ColorModel model = new ColorModel { colorspace = ColorSpace.RGB };
                FluxJpeg.Core.Image img = new FluxJpeg.Core.Image(model, raster);
                MemoryStream stream = new MemoryStream();
                JpegEncoder encoder = new JpegEncoder(img, 100, stream);
                encoder.Encode();
    
                return stream;
            }
