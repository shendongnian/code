    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        Pen pen1 = new System.Drawing.Pen(Color.Black, 3);
        Pen pen2 = new System.Drawing.Pen(panel1.BackColor, 3);
        Graphics g = panel1.CreateGraphics();
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        // Clear the graphics, creating a blank area to draw on
        g.Clear(panel1.BackColor);
        g.DrawLine(pen1, new Point(0, 0), new Point(e.Location.X, e.Location.Y));
        x_previous = e.Location.X;
        y_previous = e.Location.Y;
    }
