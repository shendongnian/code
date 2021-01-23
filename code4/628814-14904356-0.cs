        public const Int32 WM_CHAR = 0x0102;
        public void SendKeys(string message)
        {
            foreach (char c in message)
            {
                int charValue = c;
                IntPtr val = new IntPtr((Int32)c);
                SendMessage(WindowHandle, WM_CHAR, val, new IntPtr(0));
            }
        }
