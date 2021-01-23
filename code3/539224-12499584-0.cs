    protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                //case WindowsConstants.WM_HSCROLL:
                case WindowsConstants.WM_VSCROLL:
                    {
                        var nfy = m.WParam.ToInt32() & 0xFFFF;
                        if (nfy == WindowsConstants.SB_THUMBTRACK)
                        {
                            currentMsgCount++;
                            if (currentMsgCount % skipMsgCount == 0)
                                base.WndProc(ref m);
                            return;
                        }
                        if (nfy == WindowsConstants.SB_ENDSCROLL)
                            currentMsgCount = 0;
                        base.WndProc(ref m);
                    }
                    break;
                case WindowsConstants.MouseLeave:
                case WindowsConstants.NcMouseLeave:
                case WindowsConstants.MouseHover:
                case WindowsConstants.NcMouseHover:
                case WindowsConstants.Notify:
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        public const int NcMouseHover = 0x2a0;
        public const int MouseHover = 0x2a1;
        public const int NcMouseLeave = 0x2a2;
        public const int MouseLeave = 0x2a3;
        public const int Notify = 0x4e;
