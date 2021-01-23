    private static Bitmap GetBitmapFormTiff(Tiff tif)
            {
                FieldValue[] value = tif.GetField(TiffTag.IMAGEWIDTH);
                int width = value[0].ToInt();
    
                value = tif.GetField(TiffTag.IMAGELENGTH);
                int height = value[0].ToInt();
    
                //Read the image into the memory buffer
                var raster = new int[height * width];
                if (!tif.ReadRGBAImage(width, height, raster))
                {
                    return null;
                }
    
                var bmp = new Bitmap(width, height, PixelFormat.Format32bppRgb);
    
                var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    
                BitmapData bmpdata = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppRgb);
                var bits = new byte[bmpdata.Stride * bmpdata.Height];
    
                for (int y = 0; y < bmp.Height; y++)
                {
                    int rasterOffset = y * bmp.Width;
                    int bitsOffset = (bmp.Height - y - 1) * bmpdata.Stride;
    
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        int rgba = raster[rasterOffset++];
                        bits[bitsOffset++] = (byte)((rgba >> 16) & 0xff);
                        bits[bitsOffset++] = (byte)((rgba >> 8) & 0xff);
                        bits[bitsOffset++] = (byte)(rgba & 0xff);
                        bits[bitsOffset++] = (byte)((rgba >> 24) & 0xff);
                    }
                }
    
                System.Runtime.InteropServices.Marshal.Copy(bits, 0, bmpdata.Scan0, bits.Length);
                bmp.UnlockBits(bmpdata);
    
                return bmp;
            }
