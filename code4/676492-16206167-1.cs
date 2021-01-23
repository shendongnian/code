        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 WM_SETTINGCHANGE = 0x1A;
        protected override void WndProc(ref Message message)
        {
            if (message.Msg == WM_SETTINGCHANGE)
            {
                if (message.WParam.ToInt32() == SPI_SETDESKWALLPAPER)
                {
                    // Handle that wallpaper has been changed.]
                     Console.Beep();
                }
            }
            base.WndProc(ref message);
        }
