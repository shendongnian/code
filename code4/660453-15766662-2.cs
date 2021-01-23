        [DllImport("user32.dll", SetLastError = true)]
        static extern uint RegisterClipboardFormat(string lpszFormat);
        [DllImport("user32.dll")]
        static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool CloseClipboard();
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool OpenClipboard(IntPtr hWndNewOwner);
        private static void XMLSpreadSheetToClipboard(String S)
        {
            var HGlob = Marshal.StringToHGlobalAnsi(S);
            uint Format = RegisterClipboardFormat("XML SpreadSheet");
            OpenClipboard(IntPtr.Zero);
            SetClipboardData(Format, HGlob);
            CloseClipboard();
            Marshal.FreeHGlobal(HGlob);
        }
