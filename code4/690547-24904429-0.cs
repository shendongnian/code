    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TabTipTest
    {
        class Program
        {
            [DllImport("user32.dll")]
            public static extern IntPtr FindWindow(String sClassName, String sAppName);
    
            [DllImport("user32.dll")]
            public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
    
            /// <summary>
            /// The command for a user choosing a command from the Window menu (see http://msdn.microsoft.com/en-gb/library/windows/desktop/ms646360(v=vs.85).aspx).
            /// </summary>
            public const int WM_SYSCOMMAND = 0x0112;
    
            /// <summary>
            /// Closes the window.
            /// </summary>
            public const int SC_CLOSE = 0xF060;
    
            static void Main(string[] args)
            {
                HideKeyboard();
            }
    
            /// <summary>
            /// Gets the window handler for the virtual keyboard.
            /// </summary>
            /// <returns>The handle.</returns>
            public static IntPtr GetKeyboardWindowHandle()
            {
                return FindWindow("IPTip_Main_Window", null);
            }
    
            /// <summary>
            /// Hides the keyboard by sending the window the close command.
            /// </summary>
            public static void HideKeyboard()
            {
                IntPtr keyboardHandle = GetKeyboardWindowHandle();
    
                if (keyboardHandle != IntPtr.Zero)
                {
                    SendMessage(keyboardHandle, WM_SYSCOMMAND, SC_CLOSE, 0);
                }
            }
        }
    }
