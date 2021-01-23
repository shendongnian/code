    chatIcons = ChangeColor(chatIcons,(byte)255,(byte)0,(byte)255);
    
    public static Bitmap ChangeColor(Bitmap sourceBitmap, byte blue, byte green, byte red)
    {
           BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                        sourceBitmap.Width, sourceBitmap.Height),
                                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
    
           byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
    
           Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
    
           sourceBitmap.UnlockBits(sourceData);
    
           for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
           {
               if (pixelBuffer[k] == blue && pixelBuffer[k + 1] == green && pixelBuffer[k + 2] == red)
               {
                    pixelBuffer[k] = 0;
                    pixelBuffer[k + 1] = 0;
                    pixelBuffer[k + 2] = 0;
                    pixelBuffer[k + 3] = 0;
               }
            }
    
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
    
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                        resultBitmap.Width, resultBitmap.Height),
                                        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
    
             Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
                resultBitmap.UnlockBits(resultData);
    
             return resultBitmap;
    }
