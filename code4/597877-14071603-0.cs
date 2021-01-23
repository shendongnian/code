        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int TTM_RELAYEVENT = 0x407;
            if (m.Msg == TTM_RELAYEVENT)
            {
                Message relayed = (Message)Marshal.PtrToStructure(m.LParam, typeof(Message));
                if (related.Msg == WM_LBUTTONDOWN)
                {
                    // Do something
                }
            }
            base.WndProc(ref m);
        }
