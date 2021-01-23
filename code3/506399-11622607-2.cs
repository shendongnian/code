    public void SaveFormPictureBoxToBitMapIncludingDrawings(string dir, int frameIndex)
    {
        string fn = Path.Combine(dir, frameIndex.ToString("D6") + ".bmp");
        if (!File.Exists(fn))
        {
            using (Bitmap b = new Bitmap(pictureBox1.Width, pictureBox1.Height))
            {
                pictureBox1.DrawToBitmap(b, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                b.Save(fn);
            }
        } 
    }
