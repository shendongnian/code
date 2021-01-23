    public new Rectangle ClientRectangle
    {
        get
        {
            return new Rectangle(new Point(0, 0), ClientSize);
        }
    }
    
    public new Size ClientSize
    {
        get
        {
            return new Size(
                base.ClientSize.Width - VScrollBar.Width,
                base.ClientSize.Height - HScrollBar.Height
            );
        }
    }
