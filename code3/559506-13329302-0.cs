        [DllImport("user32.dll")]
        public static extern int ToUnicode(uint virtualKeyCode, ScanCodeShort scanCode,
            byte[] keyboardState,
            [Out, MarshalAs(UnmanagedType.LPWStr, SizeConst = 64)]
    StringBuilder receivingBuffer,
            int bufferSize, uint flags);
        public static string GetCharsFromKeys(ScanCodeShort keys)
        {
            var buf = new StringBuilder(256);
            var keyboardState = new byte[256];
            GetKeyState(VirtualKeyStates.VK_F3);
            GetKeyboardState(keyboardState);
            keyboardState[(int)System.Windows.Forms.Keys.ControlKey] = 0x00;
            int x = ToUnicode(MapVirtualKey(keys, 1), keys, keyboardState, buf, 256, 0);
            return buf.ToString();
        }
        [DllImport("user32.dll")]
        static extern short GetKeyState(VirtualKeyStates nVirtKey);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetKeyboardState(byte[] lpKeyState);
