        [DllImport("user32.dll")]
        private static extern int EnumDisplaySettings(string deviceName, int modeNum, ref DeviceMode devMode);
        /// <summary>
        /// Gets the max resolution + refresh rate supported by specific display
        /// </summary>
        /// <param name="deviceName">Device name(System.Windows.Forms.Screen.DeviceName)</param>
        /// <param name="dispWidth">Width of the display</param>
        /// <param name="dispHeight">Height of the display</param>
        /// <param name="refreshRate">Refresh rate of the display</param>
        /// <returns></returns>
        public static void GetMaxResolutionWithRefreshRate(string deviceName, out int dispWidth, out int dispHeight, out int refreshRate)
        {
            dispWidth = dispHeight = refreshRate = 0;
            DeviceMode deviceMode = new DeviceMode();
            for (int i = 0; Win32.EnumDisplaySettings(deviceName, i, ref deviceMode) != 0; i++)
            {
                if (deviceMode.dmPelsWidth > dispWidth || (deviceMode.dmPelsWidth == dispWidth && deviceMode.dmPelsHeight >= dispHeight && deviceMode.dmDisplayFrequency >= refreshRate))
                {
                    dispWidth = deviceMode.dmPelsWidth;
                    dispHeight = deviceMode.dmPelsHeight;
                    refreshRate = deviceMode.dmDisplayFrequency;
                }
            }
        }
    public static void GetMaxResolutionWithRefreshRate(out int dispWidth, out int dispHeight, out int refreshRate)
        {
            GetMaxResolutionWithRefreshRate(null, out dispWidth, out dispHeight, out refreshRate);
        }
