    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
         Point[] p = new Point[3];
         p[0] = new Point(10,10);
         p[1] = new Point(50,10);
         p[2] = new Point(30,50);
         e.Graphics.DrawLines(Pens.Black, p);
         e.Graphics.FillPolygon(Brushes.Red, p);
    }
