    using System.Windows.Forms;
    using System.ComponentModel;
    
    class TextBoxWithOnPaste : TextBox
    {
    
        public delegate void PastedEventHandler();
    
        [Category("Action")]
        [Description("Fires when text from the clipboard is pasted.")]
        public event PastedEventHandler OnPaste = delegate { };
    
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x302) //WM_PASTE
            {
                OnPaste();
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
