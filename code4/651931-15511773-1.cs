    void p_Click(object sender, EventArgs e)
    {
        PictureBox p = (PictureBox)sender);
        p.BackColor = p.BackColor == Color.Green ? Color.Red : Color.Green;
    }
