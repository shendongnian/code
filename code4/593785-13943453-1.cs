    private void button1_Click(object sender, EventArgs e)
    {
        using (Graphics g = panel1.CreateGraphics())
        {
            g.DrawLine(new Pen(Color.Back, 3), new Point(234,118), new Point(293,228));
        }
    }
