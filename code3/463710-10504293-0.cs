    public Point MouseXY = new Point(0, 0);
    private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseXY = e.Location;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int width = e.Location.X - MouseXY.X;
                int height = e.Location.Y-MouseXY.Y;
                this.Refresh();
                CreateGraphics().DrawRectangle(Pens.Blue, new Rectangle(MouseXY, new Size(width,height)));
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.Refresh();
        }
