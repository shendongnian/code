    private void Form1_Load(object sender, EventArgs e)
    {
        pictureBox1.Click += PictureBox_Click;
        pictureBox2.Click += PictureBox_Click;
        // and keep going
        // OR
        // this is a bit dangerous if you don't want ALL 
        // your picture boxes to have this event
        // also assumes that you know picturebox1 exists.
        foreach (object f in this.Controls)
        {
            if (f.GetType().Equals(pictureBox1.GetType()))
            {
                ((PictureBox)f).Click += button_Click;
            }
        }
    }
