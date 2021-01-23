    private const Int32 WM_SYSCOMMAND = 0x112;
            private const Int32 SC_MINIMIZE = 0xf020;
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_SYSCOMMAND)
                {
                    if (m.WParam.ToInt32() == SC_MINIMIZE)
                        return;
                }
                base.WndProc(ref m);
            }
