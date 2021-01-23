    private void button1_Click_1(object sender, EventArgs e)
    {
        DrawCircles(int.Parse(textBox1.Text));
    }
    private void DrawCircles(int size)
    {
        Bitmap b = new Bitmap(300, 300);
        using (Graphics g = Graphics.FromImage(b))
        {
            Pen p = new Pen(Brushes.Red, size);
            Pen p2 = new Pen(Brushes.Blue, 1);
            g.DrawEllipse(p, 10 - size / 2, 10-size / 2, 200 + size, 200 + size);
            g.DrawEllipse(p2, 12, 12, 196, 196);
            g.Save();
        }
        pictureBox1.Image = b;
    }
