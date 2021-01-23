    private System.Drawing.Point oldMousePos; // old mouse position
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
            System.Drawing.Point curMousePos = e.Location;
            System.Drawing.Graphics g;
            System.Drawing.Pen brush = new System.Drawing.Pen(Color.Blue, 5); // width of 5
            g = pictureBox1.CreateGraphics();
            g.DrawLine(brush, oldMousePos.X, oldMousePos.Y, curMousePos.X, curMousePos.Y); // use a pen for lines rather than a brush (between 2 points)
            g.Dispose(); // mark the graphics object for collection
            oldMousePos = curMousePos; // set old to be this (so you get a continuous line)
    }
