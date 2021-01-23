    public override void DrawSelf(Graphics grfx)
        {
            base.DrawSelf(grfx);
    
            //grfx.FillRectangle(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            //grfx.DrawRectangle(Pens.Black, Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
    
            grfx.TranslateTransform(Rectangle.X + Rectangle.Width / 2, Rectangle.Y + Rectangle.Height/2);
            grfx.RotateTransform(base.RotationAngle);
            grfx.TranslateTransform(-(Rectangle.X + Rectangle.Width / 2), -(Rectangle.Y + Rectangle.Height/2));
            grfx.FillRectangle(new SolidBrush(FillColor), Rectangle.X, Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.DrawRectangle(Pens.Black, Rectangle.X,Rectangle.Y, Rectangle.Width, Rectangle.Height);
            grfx.ResetTransform();
        }
