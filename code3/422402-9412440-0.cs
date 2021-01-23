    private void button1_Click(object sender, EventArgs e)
    {
        var halfX = pictureBox1.ClientRectangle.Width / 2;
        var halfY = pictureBox1.ClientRectangle.Height / 2;
        Random rnd = new Random();
        var offsetX = rnd.Next(-10, 10);
        var offsetY = rnd.Next(-10, 10);
        drawPoint(halfX + offsetX, halfY + offsetY);
    }
    public void drawPoint(int x, int y)
    {
        Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
        SolidBrush brush = new SolidBrush(Color.LimeGreen);
        Point dPoint = new Point(x, (pictureBox1.Height - y));
        dPoint.X = dPoint.X - 2;
        dPoint.Y = dPoint.Y - 2;
        Rectangle rect = new Rectangle(dPoint, new Size(4, 4));
        g.FillRectangle(brush, rect);
        g.Dispose();
    }
