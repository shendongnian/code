    using (var font = new Font("Arial",10,FontStyle.Regular, GraphicsUnit.Pixel))
    using (var image = new Bitmap(30, 15))
    using (var graphics = Graphics.FromImage(image))
    {
    	graphics.FillRectangle(Brushes.White, new Rectangle(0, 0, 30, 15));
    	graphics.DrawString("Ay", font, Brushes.Black, 0, 0);
    	image.Save(@"E:\test.bmp", ImageFormat.Bmp);
    }
