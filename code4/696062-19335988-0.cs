    public static class fastClipboard
    {
            [DllImport("user32.dll")]
            static extern IntPtr GetClipboardData(uint uFormat);
            [DllImport("user32.dll")]
            static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);
            [DllImport("user32.dll")]
            static extern bool IsClipboardFormatAvailable(uint format);
            [DllImport("user32.dll", SetLastError = true)]
            static extern bool OpenClipboard(IntPtr hWndNewOwner);
            [DllImport("user32.dll", SetLastError = true)]
            static extern bool CloseClipboard();
            [DllImport("kernel32.dll")]
            static extern IntPtr GlobalLock(IntPtr hMem);
            [DllImport("kernel32.dll")]
            static extern bool GlobalUnlock(IntPtr hMem);
            const uint CF_UNICODETEXT = 13;
            public static bool SetText(string data)
            {
                if (!IsClipboardFormatAvailable(CF_UNICODETEXT))
                    return false;
                if (!OpenClipboard(IntPtr.Zero))
                    return false;
                
                var ptr = Marshal.StringToHGlobalUni(data);
                var res = SetClipboardData(CF_UNICODETEXT, ptr);
                CloseClipboard();
                if (res != IntPtr.Zero)
                    return true;
                else
                    return false;
            }
            public static string GetText()
            {
                if (!IsClipboardFormatAvailable(CF_UNICODETEXT))
                    return null;
                if (!OpenClipboard(IntPtr.Zero))
                    return null;
                string data = null;
                var hGlobal = GetClipboardData(CF_UNICODETEXT);
                if (hGlobal != IntPtr.Zero)
                {
                    var lpwcstr = GlobalLock(hGlobal);
                    if (lpwcstr != IntPtr.Zero)
                    {
                        data = Marshal.PtrToStringUni(lpwcstr);
                        GlobalUnlock(lpwcstr);
                    }
                }
                CloseClipboard();
                return data;
            }
        }
