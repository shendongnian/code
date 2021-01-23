    private void button1_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.FillRectangle(Brushes.Coral, ((Button)sender).ClientRectangle);
        string txt = "Toolbox";
        Font f = new Font("Times New Roman", 8);
        SizeF szF = g.MeasureString(txt, f);
        g.TranslateTransform((float)((Button)sender).ClientRectangle.Width / (float)2 + szF.Height / (float)2, (float)((Button)sender).ClientRectangle.Height / (float)2 - (float)szF.Width / (float)2);
        g.RotateTransform(90);
        g.DrawString(txt, f, Brushes.Black, 0, 0);
        f.Dispose();
    }
