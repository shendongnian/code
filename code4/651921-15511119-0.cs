    for (int i = 1; i <= 24; i++)
    {
         PictureBox p = new PictureBox();
         p.Click += p_Click;
    }
-
    void p_Click(object sender, EventArgs e)
    {
        ((PictureBox)sender).BackColor = Color.Green;
    }
