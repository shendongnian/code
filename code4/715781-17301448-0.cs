    this.Paint += Form1_Paint;
    
    ...
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(100, 100, 200, 200);
        g.DrawEllipse(System.Drawing.Pens.Black, rectangle);
        g.DrawRectangle(System.Drawing.Pens.Red, rectangle);
    }
