    protected override void WndProc(ref Message m)
        {
            if ((UInt32)m.Msg == Constant.WM_SYSCOMMAND)
            {
                switch ((UInt32)m.WParam)
                {
                    case Constant.SC_MAXIMIZE:
                        
                    case Constant.SC_RESTORE:
                        
                    default:
                        break;
                }
            }
            base.WndProc(ref m);
        }
