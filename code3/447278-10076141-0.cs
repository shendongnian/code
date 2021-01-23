    protected override void OnPaint(PaintEventArgs pe)
    {
       // Call the OnPaint method of the base class.
       base.OnPaint(pe);
    
       // Declare and instantiate a new pen.
       System.Drawing.Pen myPen = new System.Drawing.Pen(Color.Aqua);
    
       // Draw an aqua rectangle in the rectangle represented by the control.
       pe.Graphics.DrawRectangle(myPen, new Rectangle(this.Location, 
          this.Size));
    }
