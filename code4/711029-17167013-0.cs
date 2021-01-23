    Bitmap backBuffer = null;
    int grow = 100;
    private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
    {
        if (backBuffer == null)
            backBuffer = new Bitmap(tableLayoutPanel1.Width, tableLayoutPanel1.Height);
        Graphics g = Graphics.FromImage(backBuffer);
        g.FillRectangle(Brushes.Red, (tableLayoutPanel1.Width - grow) / 2, (tableLayoutPanel1.Height - grow) / 2, grow, grow);
        e.Graphics.DrawImage(backBuffer, 0, 0, backBuffer.Width, backBuffer.Height);
        g.Dispose();
    }
    private void tableLayoutPanel1_Resize(object sender, EventArgs e)
    {
        backBuffer = null;
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        grow += 10;
        tableLayoutPanel1.Invalidate();
    }
