        protected override void WndProc(ref Message m) {
            const int WM_CLOSE = 0x10;
            if (m.Msg == WM_CLOSE) {
               base.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            }
            base.WndProc(ref m);
        }
