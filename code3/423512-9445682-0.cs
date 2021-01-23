If you **really** have a good reason not to use FormClosing, CloseReason, ..., you can override the window procedure and write something like this:
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 0x00A1;
            const int HTCLOSE = 20;
            if (m.Msg == WM_NCLBUTTONDOWN)
            {
                switch ((int)m.WParam)
                {
                    case HTCLOSE:
                        Trace.WriteLine("Close Button clicked");
                        break;
                }
            }
            base.WndProc(ref m);
        }
