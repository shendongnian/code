     public static Stream CreateThumbnail(Stream input, Int32 targetWidth, Int32 targetHeight)
        {
            output = new MemoryStream();
                using (Bitmap bitmap = new Bitmap(input))
                {
                    ImageFormat format = bitmap.RawFormat;
                    Boolean isJpeg = (format.Equals(ImageFormat.Jpeg));
                    Boolean isPng = (format.Equals(ImageFormat.Png));
                    Int32 width = bitmap.Width;
                    Int32 height = bitmap.Height;
                    getTargetSizes(out width, out height, bitmap, targetWidth, targetHeight);
                    using (Bitmap thumbnailBitmap = new Bitmap(width, height))
                    {
                        Graphics G = Graphics.FromImage(thumbnailBitmap);
                        G.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        G.DrawImage(bitmap, 0, 0, width, height);
                        thumbnailBitmap.SetResolution(72, 72);
                        if (isJpeg)
                        {
                            var codecParams = new EncoderParameters(1);
                            codecParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 80L);
                            ImageCodecInfo[] arrayICI;
                            ImageCodecInfo jpegICI = null;
                            arrayICI = ImageCodecInfo.GetImageEncoders();
                            for (int i = 0; i < arrayICI.Length; i++)
                            {
                                if (arrayICI[i].FormatDescription.Equals("JPEG"))
                                {
                                    jpegICI = arrayICI[i];
                                    break;
                                }
                            }
                            thumbnailBitmap.Save(output, jpegICI, codecParams);
                        }
                        else
                        {
                            thumbnailBitmap.Save(output, ImageFormat.Png);
                        }
                    }
                }
            return output;
        }
        private static void getTargetSizes(out Int32 targetWidth, out Int32 targetHeight, Bitmap BM, Int32 maxWidth = 150, Int32 maxHeight = 150)
        {
            Int32 startWidth = BM.Width;
            Int32 startHeight = BM.Height;
            targetWidth = startWidth;
            targetHeight = startHeight;
            Boolean resizeByWidth = false;
            Boolean resizeByHeight = false;
            if ((maxWidth > 0) && (maxHeight > 0))
            {
                if ((startWidth > maxWidth) || (startHeight > maxHeight))
                {
                    if (startHeight <= startWidth)
                    {
                        if(targetWidth > maxWidth) resizeByWidth = true;
                    }
                    else
                    {
                        if(targetHeight > maxHeight) resizeByHeight = true;
                    }
                }
            }
            else if (maxWidth > 0)
            {
                // Resize within width only
                if (startWidth > maxWidth)
                {
                    if (targetWidth > maxWidth) resizeByWidth = true;
                }
            }
            else if (maxHeight > 0)
            {
                // Resize by height only
                if (startHeight > maxHeight)
                {
                    if (targetHeight > maxHeight) resizeByHeight = true;
                }
            }
            if (resizeByWidth)
            {
                targetWidth = maxWidth;
                targetHeight = (Int32)(startHeight * ((Decimal)targetWidth / (Decimal)startWidth));
            }
            if (resizeByHeight)
            {
                targetHeight = maxHeight;
                targetWidth = (Int32)(startWidth * ((Decimal)targetHeight / (Decimal)startHeight));
            }
        }
    }
