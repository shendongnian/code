    RectangleF rect = new RectangleF(10, 10, 30, 15);
    e.Graphics.DrawRectangle(Pens.Red, Rectangle.Truncate(rect));
    RectangleF fakeRect = new RectangleF(rect.Location, new SizeF(short.MaxValue, short.MaxValue));
    Region r = e.Graphics.Clip;
    e.Graphics.SetClip(rect);            
    e.Graphics.DrawString("1 Default", this.Font, SystemBrushes.ControlText, fakeRect);
    e.Graphics.Clip = r;
