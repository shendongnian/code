        public static void SaveImage(Image image, string savedName, int width = 0, int height = 0)
        {
            Image originalImage = image;
            string filePath = savedName;
            if (width > 0 && height > 0)
            {
                Image.GetThumbnailImageAbort myCallback =
                new Image.GetThumbnailImageAbort(ThumbnailCallback);
                Image imageToSave = originalImage.GetThumbnailImage
                    (width, height, myCallback, IntPtr.Zero);
                imageToSave.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            else
            {
                originalImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
..
   
     public void SaveImage(string cardid)
        {
            if (LoadedImage != "")
            {
                if (OpenCdb != null)
                {
                    string pics = Path.GetDirectoryName(OpenCdb.FileName);
                    // Save card image
                    ImageResizer.SaveImage(CardImg.Image, pics + "\\pics\\" + cardid + ".jpg", 177, 254);
                    //Save card thumbnail
                    ImageResizer.SaveImage(CardImg.Image, pics + "\\pics\\thumbnail\\" + cardid + ".jpg", 44, 64);
                }
                else
                {
                    string pics = AppDomain.CurrentDomain.BaseDirectory;
                    // Save card image
                    ImageResizer.SaveImage(CardImg.Image,
                            pics + "pics\\" + cardid + ".jpg", 177, 254);
                    //Save card thumbnail
                    ImageResizer.SaveImage(CardImg.Image,
                           pics + "pics\\thumbnail\\" + cardid + ".jpg", 44, 64);
                }
            }
        }
