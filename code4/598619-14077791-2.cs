    float fontSize = 52;
    Bitmap bmp = Bitmap.FromFile("c:\\test.jpg");
    Graphics g = Graphics.FromImage(bmp);
    StringFormat sf = new StringFormat(StringFormatFlags.NoClip);
    sf.Alignment = StringAlignment.Center;
    sf.LineAlignment = StringAlignment.Far;
    Font f = new Font("Impact", fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
    Pen p = new Pen(ColorTranslator.FromHtml("#77090C"), 8);
    p.LineJoin = LineJoin.Round;
    Rectangle fr = new Rectangle(0, bmp.Height - f.Height, bmp.Width, f.Height);
    LinearGradientBrush b = new LinearGradientBrush(fr,  
                                                    ColorTranslator.FromHtml("#FF6493"),
                                                    ColorTranslator.FromHtml("#D00F14"),
                                                    90);
    Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
    GraphicsPath gp = new GraphicsPath();
    gp.AddString("Demo for Stack Overflow", 
                 f.FontFamily, f.Style, fontSize, r, sf);
    
    g.SmoothingMode = SmoothingMode.AntiAlias;
    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
    
    g.DrawPath(p, gp);
    g.FillPath(b, gp);
    
    gp.Dispose();
    b.Dispose();
    b.Dispose();
    f.Dispose();
    sf.Dispose();
    g.Dispose();
    
    bmp.Save("c:\\test_result.jpg", Imaging.ImageFormat.Jpeg);
    bmp.Dispose();
