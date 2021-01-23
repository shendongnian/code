    using System.Windows.Forms;
    using System.ComponentModel;
    
    class TextBoxWithOnPaste : TextBox
    {
    
        public delegate void PastedEventHandler();
    
        [Category("Action")]
        [Description("Fires when text from the clipboard is pasted.")]
        public event PastedEventHandler OnPaste;
    
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x302 && OnPaste != null) // process WM_PASTE only if the event has been subscribed to
            {
                OnPaste();
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
