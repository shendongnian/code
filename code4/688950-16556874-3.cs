            public Bitmap SetImageOpacity(Image image, float opacity)
            {
                try
                {
                    //create a Bitmap the size of the image provided  
                    Bitmap bmp = new Bitmap(image.Width, image.Height);
    
                    //create a graphics object from the image  
                    using (Graphics gfx = Graphics.FromImage(bmp))
                    {
    
                        //create a color matrix object  
                        ColorMatrix matrix = new ColorMatrix();
    
                        //set the opacity  
                        matrix.Matrix33 = opacity;
    
                        //create image attributes  
                        ImageAttributes attributes = new ImageAttributes();
    
                        //set the color(opacity) of the image  
                        attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
    
                        //now draw the image  
                        gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                    }
                    return bmp;
                }
                catch (Exception ex)
                {
                   
                    return null;
                }
            } 
            private void button1_Click(object sender, EventArgs e)
            {
                Bitmap first = new Bitmap(pictureBox1.Image); 
                Bitmap second = SetImageOpacity(pictureBox2.Image, 0.5f);
                Bitmap result = new Bitmap(first.Width, first.Height);
                Console.WriteLine(first.Width);
                Graphics g = Graphics.FromImage(result);
                g.DrawImageUnscaled(first, 0, 0);
                g.DrawImageUnscaled(second, 0, 0);
                pictureBox3.Image = result;
                result.Save("result.jpg" );
            }
        }
    }
     
