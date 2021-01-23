    private static IntPtr HookCallback(
        int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            Keys key = (Keys)vkCode;
            if (key == Keys.Capital)
            {
                Console.WriteLine("Caps Lock: " + !Control.IsKeyLocked(Keys.CapsLock)); 
            }
            if (key == Keys.NumLock)
            {
                Console.WriteLine("NumLock: " + !Control.IsKeyLocked(Keys.NumLock));
            }
            if (key == Keys.Scroll)
            {
                Console.WriteLine("Scroll Lock: " + !Control.IsKeyLocked(Keys.Scroll));
            }
            Console.WriteLine((Keys)vkCode);
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }
