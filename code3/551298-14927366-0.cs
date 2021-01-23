    public class FirstControl : Control{
       public FirstControl() {}
       protected override void OnPaint(PaintEventArgs e) {
          base.OnPaint(e);      
          e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), ClientRectangle);
       } 
    } 
