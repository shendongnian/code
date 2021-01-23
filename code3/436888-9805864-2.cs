    private bool _moving;
    private Point _startLocation;
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        _moving = true;
        _startLocation = e.Location;
    }
    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        _moving = false;
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (_moving) {
            pictureBox1.Left += e.Location.X - _startLocation.X;
            pictureBox1.Top += e.Location.Y - _startLocation.Y;
        }
    }
