        Bitmap orginal = new Bitmap(@"C:\Users\Ali\Desktop\orginal.png");
        Bitmap mask = new Bitmap(@"C:\Users\Ali\Desktop\mask.png");
        for (int i = 0; i < orginal.Width; i++)
        {
            for (int j = 0; j < orginal.Height; j++)
            {
                if (orginal.GetPixel(i, j).A == Color.Transparent.A)
                {
                    mask.SetPixel(i, j, Color.Transparent);
                }
            } 
        }
        Bitmap bitmap = new Bitmap(mask, mask.Height, mask.Height);
        using (Graphics g = Graphics.FromImage(bitmap))
        {
            g.DrawImage(mask, 0, 0);
            g.DrawImage(orginal,0,0);
        }
        pictureBox1.Image = bitmap;
