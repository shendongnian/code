    public class CustomLabel : Label
    {
        public CustomLabel()
        {            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), 0, 0);
        }
    }
