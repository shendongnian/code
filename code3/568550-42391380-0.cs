    using System.ComponentModel;
    using System.Windows.Forms;
    public class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            TextSelectionEnabled = true;
        }
        const int WM_SETFOCUS = 0x0007;
        const int WM_KILLFOCUS = 0x0008;
        [DefaultValue(true)]
        public bool TextSelectionEnabled { get; set; }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETFOCUS && !TextSelectionEnabled)
                m.Msg = WM_KILLFOCUS;
            base.WndProc(ref m);
        }
    }
