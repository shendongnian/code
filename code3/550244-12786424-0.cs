    Bitmap image = new Bitmap("image.bmp");
    Bitmap newImage = new Bitmap(image.Width, image.Height + 45);
    using(Graphics g = Graphics.FromImage(newImage))
    {
         g.FillRectangle(new SolidBrush(Color.Black), 0, image.Height, newImage.Width, 45);
         g.DrawString("Your caption"....
         g.DrawImage(image, 0, 0);
    }
