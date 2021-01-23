        private static Bitmap ExportImage(PdfDictionary image)
        {
            string filter = image.Elements.GetName("/Filter");
            switch (filter)
            {
                case "/FlateDecode":
                    return ExportAsPngImage(image);
                default:
                    throw new ApplicationException(filter + " filter not implemented");
            }
        }
        private static Bitmap ExportAsPngImage(PdfDictionary image)
        {
            int width = image.Elements.GetInteger(PdfImage.Keys.Width);
            int height = image.Elements.GetInteger(PdfImage.Keys.Height);
            int bitsPerComponent = image.Elements.GetInteger(PdfImage.Keys.BitsPerComponent);   
            var canUnfilter = image.Stream.TryUnfilter();
            var decoded = image.Stream.Value;
            Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, bmp.PixelFormat);
            Marshal.Copy(decoded, 0, bmpData.Scan0, decoded.Length);
            bmp.UnlockBits(bmpData);
            return bmp;
        }
