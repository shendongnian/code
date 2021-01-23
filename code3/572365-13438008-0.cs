    private void MainForm_MouseMove(object sender, MouseEventArgs e)
    {
        if (drawing) {
            startLocation = e.Location;
            Graphics g = this.CreateGraphics; //this cannot be cached
            Rectangle r = new Rectangle(Math.Min(startLocation.X, Cursor.Position.X),
                                        Math.Min(startLocation.Y, Cursor.Position.Y),
                                        Math.Abs(startLocation.X - Cursor.Position.X),
                                        Math.Abs(startLocation.Y - Cursor.Position.Y));
            g.FillRectangle(Brushes.Blue, r);
            g.Dispose;
    }
