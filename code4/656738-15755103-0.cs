    if (m.Msg == 0x317 || m.Msg == 0x318) //WM_PRINT, WM_PRINTCLIENT
    {
        using (Graphics g = Graphics.FromHdc(m.WParam))
        {
            //Draw here
        }
    }
