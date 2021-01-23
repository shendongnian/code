    const int GWL_STYLE = -16;
    //No ScrollBar
    const int LVS_NOSCROLL = 0x2000;
    private bool noScrollBar = false;
        public bool NoScrollBar
        {
            get { return noScrollBar; }
            set
            {
                noScrollBar = value;
                int style = (int)NativeMethods.GetWindowLong(Handle, GWL_STYLE);
                if (noScrollBar)
                {
                    NativeMethods.SetWindowLong(Handle, GWL_STYLE, style | LVS_NOSCROLL);
                }
                else
                {
                    NativeMethods.SetWindowLong(Handle, GWL_STYLE, style & ~LVS_NOSCROLL);
                }
            }
        }
