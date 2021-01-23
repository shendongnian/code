    public class ComboBoxWithBorder : ComboBox
    {
        private Color _borderColor = Color.Black;
        private ButtonBorderStyle _borderStyle = ButtonBorderStyle.Solid;
        private static int WM_PAINT = 0x000F; 
    
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                Graphics g = Graphics.FromHwnd(Handle);
                Rectangle bounds = new Rectangle(0, 0, Width, Height);
                ControlPaint.DrawBorder(g, rect, _borderColor, _borderStyle);
            }
        }
   
        [Category("Appearance")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set 
            { 
                _borderColor = value;
                Invalidate(); // causes control to be redrawn
            }
        }
        [Category("Appearance")]
        public ButtonBorderStyle BorderStyle
        {
            get { return _borderStyle; }
            set 
            { 
                _borderStyle = value;
                Invalidate();
            }
        }     
    }
