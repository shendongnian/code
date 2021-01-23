    public const int INTERNET_OPTION_REFRESH = 37;
        private const int INTERNET_OPTION_END_BROWSER_SESSION = 42;
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);
        public void RefreshBrowserSettings()
        {
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
        }
    public void SetProxy(String Proxy, String Port, bool enabled = true)
        {
            string proxy = Proxy + ":" + Port;
            string key = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(key, true);
            if (Proxy != "")
            {
                RegKey.SetValue("ProxyServer", proxy);
            }
            if (enabled && Proxy != "")
            {
                RegKey.SetValue("ProxyEnable", 1);
            }
            else
            {
                RegKey.SetValue("ProxyEnable", 0);
            }
            RefreshBrowserSettings();
        }
