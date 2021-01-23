    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Pen penBorder = new Pen(Color.Gray, 1);
        Rectangle rectBorder = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
        e.Graphics.DrawRectangle(penBorder, rectBorder);
    
        Rectangle textRec = new Rectangle(e.ClipRectangle.X + 1, e.ClipRectangle.Y + 1, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
        TextRenderer.DrawText(e.Graphics, Text, this.Font, textRec, this.ForeColor, this.BackColor, TextFormatFlags.Default);
    }
