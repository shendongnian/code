    using System.Runtime.InteropServices;
    using Windows.Devices.Input;
    namespace Your.Namespace
    {
        public static class TouchKeyboardHelper
        {
            #region < Attributes >
            private const int WmSyscommand = 0x0112; // Flag to received/send messages to the system.
            private const int ScClose = 0xF060; // Param to indicate we want to close a system window.
            #endregion < Attributes >
            #region < Properties >
            public static bool KeyboardAttached
            {
                get { return IsKeyboardAttached(); }
            }
            #endregion < Properties >
            #region < Methods >
            [DllImport("user32.dll")]
            private static extern int FindWindow(string lpClassName, string lpWindowName); // To obtain an active system window handler.
            [DllImport("user32.dll")]
            private static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam); // To send a message to the system.
            /// <summary>
            /// To detect if a real keyboard is attached to the dispositive.
            /// </summary>
            /// <returns></returns>
            private static bool IsKeyboardAttached()
            {
                KeyboardCapabilities keyboardCapabilities = new KeyboardCapabilities(); // To obtain the properties for the real keyboard attached.
                return keyboardCapabilities.KeyboardPresent != 0 ? true : false;
            }
            /// <summary>
            /// To close the soft keyboard
            /// </summary>
            public static void CloseOnscreenKeyboard()
            {
                // Retrieve the handler of the window 
                int iHandle = FindWindow("IPTIP_Main_Window", ""); // To find the soft keyboard window.
                if (iHandle > 0)
                {
                    SendMessage(iHandle, WmSyscommand, ScClose, 0); // Send a close message to the soft keyboard window.
                }
            }
            #endregion < Methods >
        }
    }
