    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            this.Location = new Point(Cursor.Position.X + e.X , Cursor.Position.Y + e.Y);
        }
    }
