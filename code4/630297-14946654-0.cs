    panel1.DrawToBitmap(...);
    // get old image 
    Bitmap oldBitmap = pictureBox2.Image;
    // set the new image
    pictureBox2.Image = bmp1;
    // now dispose the old image
    if (oldBitmap != null)
    {
        oldBitmap.Dispose();
    }
