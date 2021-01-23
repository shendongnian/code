    // Get the bitmap data from the uploaded file 
      Bitmap src = Bitmap.FromStream(fuImageFile.PostedFile.InputStream) as Bitmap;
    //*******************************
    using ( Graphics g = Graphics.FromImage((System.Drawing.Image)result) ) 
        { 
            g.DrawImage(src, 0, 0, newWidth, newHeight); 
        }
    //*******************************
 
