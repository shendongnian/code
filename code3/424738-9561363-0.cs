    Bitmap mask = Image.FromFile("../../Data/mask.bmp") as Bitmap;
            BitmapData data = mask.LockBits(new Rectangle(0, 0, (int)mask.PhysicalDimension.Width, (int)mask.PhysicalDimension.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            int bytes = Math.Abs(data.Stride) * mask.Height;            
            byte[] outPut = new byte[bytes];
            Marshal.Copy(data.Scan0, outPut, 0, bytes);
            Marshal.Copy(outPut, 0, data.Scan0, bytes);
            mask.UnlockBits(data);
            
            Bitmap test = new Bitmap(mask.Width, mask.Height, PixelFormat.Format8bppIndexed);
            test.Palette = mask.Palette;
            BitmapData testData = test.LockBits(new Rectangle(0, 0, mask.Width, mask.Height), ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            Marshal.Copy(outPut, 0, testData.Scan0, bytes);
            test.UnlockBits(data);
            test.Save("test.jpg");
