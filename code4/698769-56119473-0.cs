    static public void fillPictureBox(PictureBox pbox, Bitmap bmp)
    {
        pbox.SizeMode = PictureBoxSizeMode.Normal;
        bool source_is_wider = (float)bmp.Width / bmp.Height > (float)pbox.Width / pbox.Height;
        Bitmap resized = new Bitmap(pbox.Width, pbox.Height);
        Graphics g = Graphics.FromImage(resized);        
        Rectangle dest_rect = new Rectangle(0, 0, pbox.Width, pbox.Height);
        Rectangle src_rect;
        if (source_is_wider)
        {
            float size_ratio = (float)pbox.Height / bmp.Height;
            int sample_width = (int)(pbox.Width / size_ratio);
            src_rect = new Rectangle((bmp.Width - sample_width) / 2, 0, sample_width, bmp.Height);
        }
        else
        {
            float size_ratio = (float)pbox.Width / bmp.Width;
            int sample_height = (int)(pbox.Height / size_ratio);
            src_rect = new Rectangle(0, (bmp.Height - sample_height) / 2, bmp.Width, sample_height);
        }
        g.DrawImage(bmp, dest_rect, src_rect, GraphicsUnit.Pixel);
        g.Dispose();
        pbox.Image = resized;
    }
