            protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                m.Result= new IntPtr(-1);
                return;
            }
            base.WndProc(ref m);
        }
