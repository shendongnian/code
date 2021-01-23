        /// <summary>
        /// Show the On Screen Keyboard
        /// </summary>
        #region ShowOSK
        public static void ShowOnScreenKeyboard()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(@"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe");
            Process.Start(startInfo);
        }
        #endregion ShowOSK
        /// <summary>
        /// Hide the On Screen Keyboard
        /// </summary>
        #region HideOSK
        public static void HideOnScreenKeyboard()
        {
            uint WM_SYSCOMMAND = 274;
            uint SC_CLOSE = 61536;
            IntPtr KeyboardWnd = FindWindow("IPTip_Main_Window", null);
            PostMessage(KeyboardWnd.ToInt32(), WM_SYSCOMMAND, (int)SC_CLOSE, 0);
        }
        #endregion HideOSK
