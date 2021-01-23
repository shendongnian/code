    Rectangle oldR = null;
    private void MainForm_MouseMove(object sender, MouseEventArgs e)
    {
        if (drawing) {
            If (oldR != null) {
                this.Invalidate(oldR);
                this.Update;
            }
            startLocation = e.Location;
            Graphics g = this.CreateGraphics;
            Rectangle r = new Rectangle(Math.Min(startLocation.X, Cursor.Position.X),
                                        Math.Min(startLocation.Y, Cursor.Position.Y),
                                        Math.Abs(startLocation.X - Cursor.Position.X),
                                        Math.Abs(startLocation.Y - Cursor.Position.Y));
            oldR = r;
            g.FillRectangle(Brushes.Blue, r);
            g.Dispose;
        }
    }
    private void MainForm_MouseUp(object sender, MouseEventArgs e)
    {
        drawing = false;
        oldR = null;
    }
