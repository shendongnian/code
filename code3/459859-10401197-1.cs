    PB = new PictureBox();
    PB.Paint += new PaintEventHandler((sender, e) =>
    {
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        e.Graphics.DrawString("Text", Font, Brushes.Black, 0, 0);
    });
    //... rest of your code
