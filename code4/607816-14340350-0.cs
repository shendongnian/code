    private void rotateLastPage()
        {
            string inputfile = @"C:\\input.tif";            
            Bitmap bmap = (Bitmap)Image.FromFile(inputfile);
            int max = bmap.GetFrameCount(FrameDimension.Page);
            bmap.SelectActiveFrame(FrameDimension.Page, max-1);
            try
            {
                bmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                EncoderParameters encoderParameters = GetEncoderParameters(bmap);                
                ImageCodecInfo encoder = GetTiffEncoder();
                bmap.Save(inputfile, encoder, encoderParameters);
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Unable to rotate page {0} in file {1} due to {2}", max.ToString(), inputfile, e.Message));
            }
            bmap.Dispose();            
        }
        private static EncoderParameters GetEncoderParameters(Image image)
        {
            EncoderParameters encoderParameters = new EncoderParameters(2);
            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.Flush);
            Int16 c = BitConverter.ToInt16(image.PropertyItems[Array.IndexOf(image.PropertyIdList, 0x103)].Value, 0);
            if (c != 4 && c != 5)
            {
                throw new ArgumentException("Only CCIT4 and LZW compressed images are allowed.");
            }
            else if (c == 4)
            {
                encoderParameters.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionCCITT4);
            }
            else if (c == 5)
            {
                encoderParameters.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)EncoderValue.CompressionLZW);
            }
            return encoderParameters;
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
