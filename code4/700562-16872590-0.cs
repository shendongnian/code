    var bmp = new Bitmap(MyWidth, CMyHeight);
    var gOff = Graphics.FromImage(bmp);
    gOff.FillRectangle(new SolidBrush(Color.White), 0, 0, bmp.Width, bmp.Height);
    texturegrass = MyApp.Properties.Resources.Grass
    Rectangle[] rects = ...;
    recs = new Rectangle[1000]
    for (int i = 0; i < rects.Length; i++) {
        gOff.DrawImage(texturegrass,rects[i]);
    }
