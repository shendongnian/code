           public void ConvertThumbnails(int width, int height, byte[] filestream, string path)
          {
            // create an image object, using the filename we just retrieved
           
            var stream = new MemoryStream(filestream);
            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
             try
                  {  
                    int fullSizeImgWidth = image.Width;
                    int fullSizeImgHeight = image.Height;
                    float imgWidth = 0.0F;
                    float imgHeight = 0.0F;
                    imgWidth = width;
                    imgHeight = height;
                    Bitmap thumbNailImg = new Bitmap(image, (int)imgWidth, (int)imgHeight);
                    MemoryStream ms = new MemoryStream();
                    // Save to memory using the Jpeg format
                    thumbNailImg.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    // read to end
                    byte[] bmpBytes = ms.GetBuffer();
                    item.Attachments.Add(path, bmpBytes);
                    thumbNailImg.Dispose();
                    ms.Close();
               
            }
            catch (Exception)
            {
                image.Dispose();
            }
        }
