    public static void sendKey(IntPtr hwnd, VKeys keyCode, bool extended)
            {
                uint scanCode = MapVirtualKey((uint)keyCode, 0);
                uint lParam;
    
                //KEY DOWN
                lParam = (0x00000001 | (scanCode << 16));
                if (extended)
                {
                    lParam = lParam | 0x01000000;
                }
    
                PostMessage(hwnd, (UInt32)WMessages.WM_KEYDOWN, (IntPtr)keyCode, (IntPtr)lParam);
    
                //KEY UP
    
                PostMessage(hwnd, (UInt32)WMessages.WM_KEYUP, (IntPtr)keyCode, (IntPtr)lParam);
            }
    
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern uint MapVirtualKey(uint uCode, uint uMapType);
