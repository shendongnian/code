    private static void ExportAsPngImage(PdfDictionary image, ref int count)
        {
            int width = image.Elements.GetInteger(PdfImage.Keys.Width);
            int height = image.Elements.GetInteger(PdfImage.Keys.Height);
            var canUnfilter = image.Stream.TryUnfilter();
            byte[] decodedBytes;
            if (canUnfilter)
            {
                decodedBytes = image.Stream.Value;
            }
            else
            {
                PdfSharp.Pdf.Filters.FlateDecode flate = new PdfSharp.Pdf.Filters.FlateDecode();
                decodedBytes = flate.Decode(image.Stream.Value);
            }
            int bitsPerComponent = 0;
            while (decodedBytes.Length - ((width * height) * bitsPerComponent / 8) != 0)
            {
                bitsPerComponent++;
            }
            System.Drawing.Imaging.PixelFormat pixelFormat;
            switch (bitsPerComponent)
            {
                case 1:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format1bppIndexed;
                    break;
                case 8:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format8bppIndexed;
                    break;
                case 16:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format16bppArgb1555;
                    break;
                case 24:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
                    break;
                case 32:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
                    break;
                case 64:
                    pixelFormat = System.Drawing.Imaging.PixelFormat.Format64bppArgb;
                    break;
                default:
                    throw new Exception("Unknown pixel format " + bitsPerComponent);
            }
            decodedBytes = decodedBytes.Reverse().ToArray();
            Bitmap bmp = new Bitmap(width, height, pixelFormat);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            int length = (int)Math.Ceiling(width * (bitsPerComponent / 8.0));
            for (int i = 0; i < height; i++)
            {
                int offset = i * length;
                int scanOffset = i * bmpData.Stride;
                Marshal.Copy(decodedBytes, offset, new IntPtr(bmpData.Scan0.ToInt32() + scanOffset), length);
            }
            bmp.UnlockBits(bmpData);
            bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
            bmp.Save(String.Format("exported_Images\\Image{0}.png", count++), System.Drawing.Imaging.ImageFormat.Png);
        }
