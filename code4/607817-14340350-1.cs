    public void rotateLastPage()
        {
            string inputfile = @"u:\\input.tiff";
            Bitmap bmap = (Bitmap)Image.FromFile(inputfile);
            int max = bmap.GetFrameCount(FrameDimension.Page);
            
            try
            {
                EncoderParameters encoderParameters = GetEncoderParameters(bmap, EncoderValue.MultiFrame);
                ImageCodecInfo encoder = GetTiffEncoder();
                var firstPage = (Image)bmap.Clone();
                firstPage.Save(inputfile+".tmp", encoder, encoderParameters);
                for (int i = 1; i < max - 1; i++)
                {
                    bmap.SelectActiveFrame(FrameDimension.Page, i);
                    encoderParameters = GetEncoderParameters(bmap, EncoderValue.FrameDimensionPage);
                    firstPage.SaveAdd(bmap, encoderParameters);
                }
                bmap.SelectActiveFrame(FrameDimension.Page, max - 1);
                bmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                encoderParameters = GetEncoderParameters(bmap, EncoderValue.FrameDimensionPage);
                firstPage.SaveAdd(bmap, encoderParameters);
                firstPage.SaveAdd(GetEncoderParameters(EncoderValue.Flush));
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Unable to rotate page {0} in file {1} due to {2}", max.ToString(), inputfile, e.Message));
            }
            bmap.Dispose();
        }
        private static EncoderParameters GetEncoderParameters(Image image, EncoderValue encoderValue)
        {
            EncoderParameters encoderParameters = new EncoderParameters(2);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)encoderValue);
            encoderParameters.Param[1] = GetCompressionEncoder(image);
            return encoderParameters;
        }
        private static EncoderParameters GetEncoderParameters(EncoderValue encoderValue)
        {
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)encoderValue);            
            return encoderParameters;
        }
        private static EncoderParameter GetCompressionEncoder(Image image)
        {
            Int16 c = BitConverter.ToInt16(image.PropertyItems[Array.IndexOf(image.PropertyIdList, 0x103)].Value, 0);
            if (c == 4)
            {
                return new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
            }
            else if (c == 5)
            {
                return new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW);
            }
            throw new ArgumentException("Only CCIT4 and LZW compressed images are allowed.");
        }
        private static ImageCodecInfo GetTiffEncoder()
        {
            ImageCodecInfo encoder = null;
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < encoders.Length; i++)
            {
                if (encoders[i].MimeType == "image/tiff")
                {
                    encoder = encoders[i];
                }
            }
            if (encoder == null)
            {
                throw new NotSupportedException("Unable to find a tiff encoder.");
            }
            return encoder;
        }
