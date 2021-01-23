    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        System.Drawing.Graphics graphicsObj = e.Graphics;
        Pen myPen = new Pen(System.Drawing.Color.Red, 5);
        Rectangle myRectangle = new Rectangle(20, 20, 250, 200);
        graphicsObj.DrawRectangle(myPen, myRectangle);
    }
