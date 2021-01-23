        public bool PreFilterMessage(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_MOUSEWHEEL:   // 0x020A
                case WM_MOUSEHWHEEL:  // 0x020E
                    IntPtr hControlUnderMouse = WindowFromPoint(new Point((int)m.LParam));
                    if (hControlUnderMouse == m.HWnd)
                        return false; // already headed for the right control
                    else
                    {
                        // redirect the message to the control under the mouse
                        SendMessage(hControlUnderMouse, m.Msg, m.WParam, m.LParam);
                        return true;
                    } 
                 default: 
                    return false; 
               } 
    }
