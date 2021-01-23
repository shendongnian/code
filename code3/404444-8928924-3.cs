    protected override void OnPaint(PaintEventArgs e) {
      switch (_TextAlign) {
        case ContentAlignment.MiddleCenter: {
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, Color.Empty, 
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            break;
          }
        case ContentAlignment.MiddleLeft: {
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, Color.Empty,
                                  TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            break;
          }
        // more case statements here for all alignments, etc.
      }
      base.OnPaint(e);
    }
   
