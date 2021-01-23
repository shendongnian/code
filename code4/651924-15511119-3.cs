    for (int i = 1; i <= 24; i++)
    {
         PictureBox p = new PictureBox();
         p.Click += p_Click;
         //of course, somecontrol.Controls.Add(p);
         //for ex: this.Controls.Add(p);
    }
-
    void p_Click(object sender, EventArgs e)
    {
        ((PictureBox)sender).BackColor = Color.Green;
    }
