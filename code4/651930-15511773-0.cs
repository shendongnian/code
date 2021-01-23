    for (int i = 1; i <= 24; i++)
    {
        PictureBox p = new PictureBox();
        p.Name = "pictureBox" + i;
        p.Click += p_Click; // <----------
        ls.Add(p);
    }
