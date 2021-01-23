            private const int WM_MOUSEACTIVATE = 0x0021;
            private const int MA_NOACTIVATEANDEAT = 0x0004;
            protected override void WndProc(ref Message m)
            {
                if (mousestatus == 0)
                {
                    if (m.Msg == WM_MOUSEACTIVATE)
                    {
                        m.Result = (IntPtr)MA_NOACTIVATEANDEAT;
                        return;
                    }
                    base.WndProc(ref m);
                }
            }
