            Image image1 = GetFirstImage();
            Image image2 = GetSecondImage();
            var bitmapImage = new Bitmap(Math.Max(image1.Width, image1.Width), (image1.Height + image2.Height));
            
            using (Graphics g = Graphics.FromImage(bitmapImage))
            {
                g.DrawImage(image1, 0, 0);
                g.DrawImage(image2, 0, image1.Height);
            }
