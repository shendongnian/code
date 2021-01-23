    //I created a new bitmap with the size of the part of image that I selected
    Bitmap bmp = new Bitmap(newImage.Width, newImage.Height);
    Graphics g = Graphics.FromImage(bmp);
    //So here I drawed in the bitmap a rectangle with the picturebox backcolor that rappresent the "blank" part of image
    g.FillRectangle(new SolidBrush(mainPictureBox.BackColor), new Rectangle(new Point(0, 0), newImage.Size));
    
    //Now draw the "blank" part on the main image
    g = Graphics.FromImage(image);
    g.DrawImage(bmp, clickedPointOne);
