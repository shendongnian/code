    public Bitmap Color(Bitmap original)
            {
                //create a blank bitmap the same size as original
                Bitmap newBitmap = new Bitmap(original.Width, original.Height);
    
                //get a graphics object from the new Image
                Graphics g = Graphics.FromImage(newBitmap);
    
                //create the color you want ColorMatrix
                //now is set to red, but with different values 
                //you can get anything you want.
                ColorMatrix colorMatrix = new ColorMatrix(
                    new float[][]
                    {
    
                        new float[] {1f, .0f, .0f, 0, 0},
                        new float[] {1f, .0f, .0f, 0, 0},
                        new float[] {1f, .0f, .0f, 0, 0},
                        new float[] {0, 0, 0, 1, 0},
                        new float[] {0, 0, 0, 0, 1}
                    });
    
                //create some image attributes
                ImageAttributes attributes = new ImageAttributes();
    
                //set the color matrix attribute
                attributes.SetColorMatrix(colorMatrix);
    
                //draw original image on the new image using the color matrix
                g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                    0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
    
                //release sources used
                g.Dispose();
                return newBitmap;
            }
