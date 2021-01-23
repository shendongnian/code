    // A new bitmap with the same size as the PictureBox
    var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
    
    //Get the graphics objectm which we can use to draw
    var graphics = Graphics.FromImage(bitmap);
    
    //Draw stuff
    graphics.FillRectangle(Brushes.Red, new Rectangle(0, 0, 500, 500));
    
    //Show the bitmap with graphics image in the PictureBox
    pictureBox1.Image = bitmap;
