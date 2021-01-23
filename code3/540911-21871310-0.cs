        /// <summary>
        /// Convert Tiff image to another mime-type bitmap
        /// </summary>
        /// <param name="tiffImage">Source TIFF file</param>
        /// <param name="mimeType">Desired result mime-type</param>
        /// <returns>Converted image</returns>
        public Bitmap ConvertTiffToBitmap(Image tiffImage, string mimeType)
        {
            var imageCodecInfo = ImageCodecInfo.GetImageEncoders().FirstOrDefault(encoder => encoder.MimeType == "image/tiff");
            if (imageCodecInfo == null)
            {
                return null;
            }
            using (var memoryStream = new MemoryStream())
            {
                var imageEncoderParams = new EncoderParameters(1);
                imageEncoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                tiffImage.Save(memoryStream, imageCodecInfo, imageEncoderParams);
                var ic = new ImageConverter();
                var tempTiffImage = (Image)ic.ConvertFrom(memoryStream.GetBuffer());
                var imageTempPath = Path.Combine(Path.GetTempPath(), "tempTiff.tmp");
                // Setting new result mime-type
                imageCodecInfo = ImageCodecInfo.GetImageEncoders().FirstOrDefault(encoder => encoder.MimeType == mimeType);
                if (tempTiffImage != null) tempTiffImage.Save(imageTempPath, imageCodecInfo, imageEncoderParams);
                var sourceImg = (Bitmap)Image.FromFile(imageTempPath, true);
                return sourceImg;
            }
        }
