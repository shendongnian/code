    Graphics GR;
    Bitmap BM;
    Rectangle myrect = new Rectangle(10,10,10,10);
    Pen penTest = new System.Drawing.Pen(Brushes.Red);
    using (GR = Graphics.FromImage(BM))
    {
        GR.DrawRectangle(penTest, myrect);
    }
    picturebox1.Image = BM;
