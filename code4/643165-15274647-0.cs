                    using(Bitmap MyImage = new Bitmap(openFileDialog1.FileName))
                    {
                      pictureBox1.Image = (Image)MyImage;
                      int imageWidth = pictureBox1.Image.Width;
                      int picBoxWidth = pictureBox1.Width;
                      if (imageWidth != 0 && picBoxWidth > imageWidth)
                      {
                          pictureBox1.Width = imageWidth;
                      }
                      else
                      {
                          pictureBox1.Width = defaultPicBoxWidth;
                      }
                    }
