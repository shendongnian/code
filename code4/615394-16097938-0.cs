     protected override void WndProc(ref Message m)
             {
                 switch (m.Msg)
                 {
                     case 0x021:
                         {
                             Message mm = new Message();
                             mm.Msg = 0x007;
                             base.WndProc(ref mm);
                         }
                         break;
                 }
                 base.WndProc(ref m);
             }
