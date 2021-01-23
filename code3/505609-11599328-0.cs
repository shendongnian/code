    public Bitmap Combine()
            {
                //read all images into memory
                List<Bitmap> images = new List<Bitmap>();
                Bitmap finalImage = null;
    
                try
                {
                    int width = 0;
                    int height = 0;
    
                    foreach (var image in files)
                    {
                        //create a Bitmap from the file and add it to the list
                        System.Drawing.Bitmap bitmap = new Bitmap(image.Filename);
    
                        //update the size of the final bitmap
                        width += bitmap.Width;
                        height = bitmap.Height > height ? bitmap.Height : height;
    
                        images.Add(bitmap);
                    }
    
                    //create a bitmap to hold the combined image
                    finalImage = new System.Drawing.Bitmap(width, height);
    
                    //get a graphics object from the image so we can draw on it
                    using (Graphics g = Graphics.FromImage(finalImage))
                    {
                        //set background color
                        g.Clear(Color.Black);
    
                        //go through each image and draw it on the final image
                        int offset = 0;
                        foreach (Bitmap image in images)
                        {
                            g.DrawImage(image,
                              new Rectangle(offset, 0, image.Width, image.Height));
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
                    foreach (Bitmap image in images)
                    {
                        image.Dispose();
                    }
                }
            }
