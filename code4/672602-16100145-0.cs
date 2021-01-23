    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Image img = Image.FromFile("C:\filepath\filename.jpg");
        e.Graphics.DrawImage(img, 0, 0);
        var YourTipTextPoint = new Point(0,0);
        e.Graphics.DrawString("Hello World", SystemFonts.DefaultFont, Brushes.Black, YourTipTextPoint); 
    }
