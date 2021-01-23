    private void saveImage()
        {
            Bitmap bmp1 = new Bitmap(pictureBox.Image);
    
           if(System.IO.File.Exists("c:\\t.jpg"))
                  System.IO.File.Delete("c:\\t.jpg");
    
            bmp1.Save("c:\\t.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            // Dispose of the image files.
            bmp1.Dispose();
        }
