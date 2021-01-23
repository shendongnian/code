    public class ComboBoxWithBorder : ComboBox
    {
        public ComboBoxWithBorder()
        {
            BorderColor = Color.Black;
            BorderStyle = ButtonBorderStyle.Solid;
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
    
            Graphics g = e.Graphics;
            ControlPaint.DrawBorder(g, e.ClipRectangle, BorderColor, BorderStyle);
        }
    
        public Color BorderColor { get; set; }
        public ButtonBorderStyle BorderStyle { get; set; }        
    }
