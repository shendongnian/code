    using (Bitmap b = new Bitmap(pictureBox1.Width, pictureBox1.Height))
    {
    	pictureBox1.DrawToBitmap(b, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
    	b.Save(@"d:\testit.png", System.Drawing.Imaging.ImageFormat.Png);
    } 
