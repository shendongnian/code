    internal const int WM_NCMOUSEMOVE = 0x00A0;
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_NCMOUSEMOVE)
        {
            if ((int)m.WParam == 0x8)
                Console.WriteLine("Mouse over on Minimize button");
            if ((int)m.WParam == 0x9)
                Console.WriteLine("Mouse over on Maximize button");
            if ((int)m.WParam == 0x14)
                Console.WriteLine("Mouse over on Close button");
        }
        base.WndProc(ref m);
    }
