    public override void DrawPlaceholder (RectangleF rect)
    {
        using (UIFont font = UIFont.SystemFontOfSize (16))
        using (UIColor col = new UIColor (0,0,255.0,0.7)) {
            col.SetFill ();
            Placeholder.DrawString (rect, font);
        }
    }
