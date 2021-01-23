    private void button1_MouseDown(object sender, MouseEventArgs e)
    {
        // replace "button_image.png" with the filename of the image you are using
        Image normalImage = Image.FromFile("button_image.png");
        Image mouseDownImage = new Bitmap(normalImage.Width + 1, normalImage.Height + 1);
        Graphics g = Graphics.FromImage(mouseDownImage);
        // this will draw the normal image at an offset on mouseDownImage
        g.DrawImage(normalImage, 1, 1); // offset is one pixel each for x and y
        // clean up
        g.Dispose();
        button1.Image = mouseDownImage;
    }
    
    private void button1_MouseUp(object sender, MouseEventArgs e)
    {
        // reset image to the normal one
        button1.Image = Image.FromFile("button_image.png");
    }
