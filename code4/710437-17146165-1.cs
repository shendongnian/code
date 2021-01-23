        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0112)  //WM_SYSCOMMAND
            {
                if (((Int32)m.WParam & 0xFFF0) == 0xF030 ||
                    ((Int32)m.WParam & 0xFFF0) == 0xF120)
                    m.WParam = new IntPtr(0xF020);
            }
            base.WndProc(ref m);
        }
