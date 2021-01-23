    float fontSize = 52;
    //some test image for this demo
    Bitmap bmp = (Bitmap)Image.FromFile(s"test.jpg");
    Graphics g = Graphics.FromImage(bmp);
    //this will center align our text at the bottom of the image
    StringFormat sf = new StringFormat();
    sf.Alignment = StringAlignment.Center;
    sf.LineAlignment = StringAlignment.Far;
    //define a font to use.
    Font f = new Font("Impact", fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
    //pen for outline - set width parameter
    Pen p = new Pen(ColorTranslator.FromHtml("#77090C"), 8);
    p.LineJoin = LineJoin.Round; //prevent "spikes" at the path
    //this makes the gradient repeat for each text line
    Rectangle fr = new Rectangle(0, bmp.Height - f.Height, bmp.Width, f.Height);
    LinearGradientBrush b = new LinearGradientBrush(fr,  
                                                    ColorTranslator.FromHtml("#FF6493"),
                                                    ColorTranslator.FromHtml("#D00F14"),
                                                    90);
    //this will be the rectangle used to draw and auto-wrap the text.
    //basically = image size
    Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
    GraphicsPath gp = new GraphicsPath();
    //look mom! no pre-wrapping!
    gp.AddString("Demo for Stack Overflow", 
                 f.FontFamily, (int)f.Style, fontSize, r, sf);
    //these affect lines such as those in paths. Textrenderhint doesn't affect
    //text in a path as it is converted to ..well, a path.    
    g.SmoothingMode = SmoothingMode.AntiAlias;
    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
    //TODO: shadow -> g.translate, fillpath once, remove translate
    g.DrawPath(p, gp);
    g.FillPath(b, gp);
    
    //cleanup
    gp.Dispose();
    b.Dispose();
    b.Dispose();
    f.Dispose();
    sf.Dispose();
    g.Dispose();
    
    bmp.Save(s"test_result.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
    bmp.Dispose();
