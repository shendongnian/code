    public void myText_MouseMove(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            if (e.Button == MouseButtons.Left)
            {
                button .Left += e.X - move.X;
                button .Top += e.Y - move.Y;
            }
        }
