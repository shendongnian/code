    protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
                // mouse in window or in Border and max, close & min buttons     
                if (m.Msg == 0xa0 || m.Msg == 0x200)
                {
                    //Do some thing
                }
            }
