        [CLSCompliant(false)]
        [DllImport("user32.dll", EntryPoint = "MessageBox")]
        public static extern int MessageBoxUser32(int hWnd, String text, String caption, uint type);
        const uint MB_TOPMOST = 0x00040000;
        const uint MB_OK  = 0x00000000;
        const uint MB_OKCANCEL = 0x00000001;
        const uint MB_ABORTRETRYIGNORE = 0x00000002;
        const uint MB_YESNOCANCEL = 0x00000003;
        const uint MB_YESNO = 0x00000004;
        const uint MB_RETRYCANCEL = 0x00000005;
		
		 public static void ShowMessageBox(string message, bool topMost = true
            , string title = null, MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            if(topMost)
            {
                uint mbv = MB_TOPMOST;
   
                if (buttons == MessageBoxButtons.OK)
                    mbv |= MB_OK;
                if (buttons == MessageBoxButtons.OKCancel)
                    mbv |= MB_OKCANCEL;
                if (buttons == MessageBoxButtons.AbortRetryIgnore)
                    mbv |= MB_ABORTRETRYIGNORE;
                if (buttons == MessageBoxButtons.YesNoCancel)
                    mbv |= MB_YESNOCANCEL;
                if (buttons == MessageBoxButtons.YesNo)
                    mbv |= MB_YESNO;
                if (buttons == MessageBoxButtons.RetryCancel)
                    mbv |= MB_RETRYCANCEL;
                MessageBoxUser32(0, message, title == null ? string.Empty : title, MB_TOPMOST);
            }
            else
            {
                MessageBox.Show(message, title == null ? string.Empty : title, buttons);
            }
        }
