    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Pen myPen = new Pen(Color.Red, 5);
        g.DrawRectangle(myPen, 20, 20, 250, 200);
    }
