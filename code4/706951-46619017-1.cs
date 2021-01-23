    public class MyLabel : System.Windows.Forms.Label
    {
        private const int WM_LBUTTONDBLCLK = 0x203;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK)
            {
                string sSaved = Clipboard.GetText();
                System.Drawing.Image iSaved = Clipboard.GetImage();
                base.WndProc(ref m);
                if (iSaved != null) Clipboard.SetImage(iSaved);
                if (!string.IsNullOrEmpty(sSaved)) Clipboard.SetText(sSaved);
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
