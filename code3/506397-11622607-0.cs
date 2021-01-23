    public void SaveFormPicutreBoxToBitMapIncludingDrawings(int frameIndex)
    {
        using (Bitmap b = new Bitmap(pictureBox1.Width, pictureBox1.Height))
        {
            pictureBox1.DrawToBitmap(b, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            string fn = @"d:\PictureBoxToBitmap\" + frameIndex.ToString("D6") + ".bmp";
            if (!File.Exists(fn))
            {
                b.Save(fn);
            }
        } 
    }
