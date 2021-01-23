    public class WTextBox : TextBox
    {
        private string _placeholder;
        [Category("Appearance")]
        public string Placeholder
        {
            get { return _placeholder; }
            set
            {
                _placeholder = value ?? string.Empty;
                Invalidate();
            }
        }
        public WTextBox()
        {
            _placeholder = string.Empty;
        }
        
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg != 0xF || Focused || !string.IsNullOrEmpty(Text) || string.IsNullOrWhiteSpace(_placeholder))
            {
                return;
            }
            
            using (var g = CreateGraphics())
            {
                TextRenderer.DrawText(g, _placeholder, Font, ClientRectangle, SystemColors.GrayText, BackColor, TextFormatFlags.Left);
            }
        }
    }
