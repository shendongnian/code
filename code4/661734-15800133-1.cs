    protected override void OnPaint(PaintEventArgs pevent)
    {
       // do not call the base class implementation
       // base.OnPaint(e);
    	
       // erase the background
       pevent.Graphics.FillRectangle(SystemBrushes.Control, this.ClientRectangle);
       
       // draw the image at the top-left
       pevent.Graphics.DrawImage(this.Image, Point.Empty);
    }
