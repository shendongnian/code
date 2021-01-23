    public class CornerLabel : Label
    {
       public string Text2 { get; set; }
    
       public CornerLabel()
       {
          // This label doesn't support autosizing because the default autosize logic
          // only knows about the primary caption, not the secondary one.
          // 
          // You will either have to set its size manually, or override the
          // GetPreferredSize function and write your own logic. That would not be
          // hard to do: use TextRenderer.MeasureText to determine the space
          // required for both of your strings.
          this.AutoSize = false;
       }
    
       protected override void OnPaint(PaintEventArgs e)
       {
          // Call the base class to paint the regular caption in the top-left.
          base.OnPaint(e);
    
          // Paint the secondary caption in the bottom-right.
          TextRenderer.DrawText(e.Graphics,
                                this.Text2,
                                this.Font,
                                this.ClientRectangle,
                                this.ForeColor,
                                TextFormatFlags.Bottom | TextFormatFlags.Right);
       }
    }
    
