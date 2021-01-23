    pictureBox.MouseMove += pictureBox_View_MouseMove;
    private void pictureBox_View_MouseMove(object sender, MouseEventArgs e)
    {
        Xcoord.Text = e.x.ToString();
        Ycoord.Text = e.y.ToString();
    }
