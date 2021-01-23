    public class TextBoxWithoutFocus : TextBox
    {
        private const int WM_SETFOCUS = 0x7;
    
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETFOCUS)
                return;
    
            base.WndProc(ref m);
        }
    }
