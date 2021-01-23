    public static System.Drawing.Bitmap CombineBitmap(Image[] files)
            {
                //read all images into memory
                List<System.Drawing.Bitmap> images = new List<System.Drawing.Bitmap>();
                System.Drawing.Bitmap finalImage = null;
    
                try
                {
                    int width = 0;
                    int height = 0;
    
                    foreach (Image image in files)
                    {
                        //create a Bitmap from the file and add it to the list
                        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(image);
    
                        //update the size of the final bitmap
                        width += bitmap.Width;
                        height = bitmap.Height > height ? bitmap.Height : height;
    
                        images.Add(bitmap);
                    }
    
                    //create a bitmap to hold the combined image
                    finalImage = new System.Drawing.Bitmap(width, height);
    
                    //get a graphics object from the image so we can draw on it
                    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(finalImage))
                    {
                        //set background color
                        g.Clear(System.Drawing.Color.Black); // Change this to whatever you want the background color to be, you may set this to Color.Transparent as well
    
                        //go through each image and draw it on the final image
                        int offset = 0;
                        foreach (System.Drawing.Bitmap image in images)
                        {
                            g.DrawImage(image,
                              new System.Drawing.Rectangle(offset, 0, image.Width, image.Height));
                            offset += image.Width;
                        }
                    }
    
                    return finalImage;
                }
                catch (Exception ex)
                {
                    if (finalImage != null)
                        finalImage.Dispose();
    
                    throw ex;
                }
                finally
                {
                    //clean up memory
                    foreach (System.Drawing.Bitmap image in images)
                    {
                        image.Dispose();
                    }
                }
            }
