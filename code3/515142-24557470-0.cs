    public static string[] ConvertJpegToTiff(string[] fileNames, bool isMultipage)
        {
            EncoderParameters encoderParams = new EncoderParameters(1);
            ImageCodecInfo tiffCodecInfo = ImageCodecInfo.GetImageEncoders()
                .First(ie => ie.MimeType == "image/tiff");
            string[] tiffPaths = null;
            if (isMultipage)
            {
                tiffPaths = new string[1];
                System.Drawing.Image tiffImg = null;
                try
                {
                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        if (i == 0)
                        {
                            tiffPaths[i] = String.Format("{0}\\{1}.tif",
                                Path.GetDirectoryName(fileNames[i]),
                                Path.GetFileNameWithoutExtension(fileNames[i]));
                            // Initialize the first frame of multipage tiff.
                            tiffImg = System.Drawing.Image.FromFile(fileNames[i]);
                            encoderParams.Param[0] = new EncoderParameter(
                                System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
                            tiffImg.Save(tiffPaths[i], tiffCodecInfo, encoderParams);
                        }
                        else
                        {
                            // Add additional frames.
                            encoderParams.Param[0] = new EncoderParameter(
                                System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.FrameDimensionPage);
                            using (System.Drawing.Image frame = System.Drawing.Image.FromFile(fileNames[i]))
                            {
                                tiffImg.SaveAdd(frame, encoderParams);
                            }
                        }
                        if (i == fileNames.Length - 1)
                        {
                            // When it is the last frame, flush the resources and closing.
                            encoderParams.Param[0] = new EncoderParameter(
                                System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.Flush);
                            tiffImg.SaveAdd(encoderParams);
                        }
                    }
                }
                finally
                {
                    if (tiffImg != null)
                    {
                        tiffImg.Dispose();
                        tiffImg = null;
                    }
                }
            }
            else
            {
                tiffPaths = new string[fileNames.Length];
                for (int i = 0; i < fileNames.Length; i++)
                {
                    tiffPaths[i] = String.Format("{0}\\{1}.tif",
                        Path.GetDirectoryName(fileNames[i]),
                        Path.GetFileNameWithoutExtension(fileNames[i]));
                    // Save as individual tiff files.
                    using (System.Drawing.Image tiffImg = System.Drawing.Image.FromFile(fileNames[i]))
                    {
                        tiffImg.Save(tiffPaths[i], ImageFormat.Tiff);
                    }
                }
            }
            return tiffPaths;
        }
