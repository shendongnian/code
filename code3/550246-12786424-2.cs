    Bitmap image = new Bitmap("image.bmp");
    Bitmap newImage = new Bitmap(image.Width, image.Height + 40);
    using(Graphics g = Graphics.FromImage(newImage))
    {
         // Draw base image
         g.DrawImageUnscaled(image, 0, 0);
         //Fill undrawn area
         g.FillRectangle(new SolidBrush(Color.Black), 0, image.Height, newImage.Width, 40);
         // Create font
         Font font = new Font("Times New Roman", 42.0f);
         // Create text position (play with positioning)
         PointF point = new PointF(image.Width, image.Height+10);
         // Draw text
         g.DrawString("Watermark", font, Brushes.Red, point);
    }
