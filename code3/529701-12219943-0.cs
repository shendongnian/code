    private void button1_Click(object sender, EventArgs e)
    {
        Bitmap tempBuffer = new Bitmap(100, 100);
        using (Graphics g = Graphics.FromImage(tempBuffer))
        using (SolidBrush blackBrush = new SolidBrush(Color.Black))
        {
            g.FillRectangle(blackBrush, new Rectangle(0, 0, tempBuffer.Width-1, tempBuffer.Height-1);
        }
        buffer = tempBuffer;
        panel1.Invalidate();
    }
