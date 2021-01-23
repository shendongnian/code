    private void Form1_Load(object sender, EventArgs e)
    {
        for (int i = 1; i <= 24; i++)
        {
            PictureBox p = new PictureBox();
            p.Name = "pictureBox" + i;
            p.Click += PictureBox_Click;
        }
    }
    
    void PictureBox_Click(object sender, EventArgs e)
    {
        PictureBox event_picturebox = (PictureBox)sender;
        event_picturebox.BackColor = Color.White;
    }
