    public class MyLabel : System.Windows.Forms.Label
    {
        private const int WM_LBUTTONDBLCLK = 0x203;
        private string sSavedText = "";
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK)
            {
                sSavedText = Clipboard.GetText();
                base.WndProc(ref m);
                Clipboard.SetText(sSavedText);
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
