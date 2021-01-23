    Bitmap image = new Bitmap("path/resource");
    Bitmap newImage = new Bitmap(image.Width, image.Height + 40);
    using (Graphics g = Graphics.FromImage(newImage))
    {
          // Draw base image
          Rectangle rect = new Rectangle(0, 0, image.Width, image.Height); 
          g.DrawImageUnscaledAndClipped(image, rect);
          //Fill undrawn area
          g.FillRectangle(new SolidBrush(Color.Black), 0, image.Height, newImage.Width, 40);
          // Create font
          Font font = new Font("Times New Roman", 22.0f);
          // Create text position (play with positioning)
          PointF point = new PointF(0, image.Height);
          // Draw text
          g.DrawString("Watermark", font, Brushes.Red, point);
     }
