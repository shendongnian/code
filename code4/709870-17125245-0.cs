    private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
    {
        Pen graphPen = new Pen(Color.Red, 2);
        Point pt1D = new Point();
        Point pt2D = new Point();
        int xCoord = int.Parse(textBox3.Text);
        pt1D.X = xCoord;
        e.Graphics.DrawLine(graphPen, pt1D, pt2D);
    }  
 
