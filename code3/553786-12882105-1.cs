    List<PictureBox> pictureBoxes = new List<PictureBox>();
    for (int i = 0; i < 10; i++)
    {
        PictureBox pb = new PictureBox();
        pb.Location = new Point(.....);
        pb.Size = ......;
        pb.Click += pb_Click;
        Controls.Add(pb);
        pictureBoxes.Add(pb);
    }
    pictureBoxes[3].Image=..... //Use like this
---
    void pb_Click(object sender, EventArgs e)
    {
        PictureBox pb = sender as PictureBox;
        //Do work
    }
