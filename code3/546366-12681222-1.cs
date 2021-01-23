        using (Image sourceImg = Image.FromFile(open.Filename))
        {
            Image clonedImg = new Bitmap(sourceImg.Width, sourceImg.Height, PixelFormat.Format32bppArgb);
            using (var copy = Graphics.FromImage(clonedImg))
            {
                copy.DrawImage(sourceImg, 0, 0);
            }
            pictureBox1.InitialImage = null;
            pictureBox1.Image = clonedImg;
        }
