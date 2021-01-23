    public static void sendKey(IntPtr hwnd, VKeys keyCode, bool extended)
    {
        uint scanCode = MapVirtualKey((uint)keyCode, 0);
        uint lParam;
    
        //KEY DOWN
        lParam = (0x00000001 | (scanCode << 16));
        if (extended)
        {
            lParam |= 0x01000000;
        }
        PostMessage(hwnd, (UInt32)WMessages.WM_KEYDOWN, (IntPtr)keyCode, (IntPtr)lParam);
    
        //KEY UP
        lParam |= 0xC0000000;  // set previous key and transition states (bits 30 and 31)
        PostMessage(hwnd, WMessages.WM_KEYUP, (uint)keyCode, lParam);
    }
    
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern uint MapVirtualKey(uint uCode, uint uMapType);
