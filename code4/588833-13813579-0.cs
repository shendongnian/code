    public class InputHelper
    {
        #region Static Members
    
        /// <summary>
        /// Determines whether the key value pressed originated from the SIP
        /// </summary>
        /// <param name="keyValue">The key value.</param>
        /// <param name="handle">The widget handle.</param>
        /// <returns>
        ///   <c>true</c> if is sip key press; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSipKeyPress(int keyValue, IntPtr handle)
        {
            NativeMessage m;
            if (PeekMessage(out m, handle, 0, 0, PM_NOREMOVE))
            {
                // All SIP inputs have LParam of 1, so ignore these
                if (m.msg == WM_CHAR && m.wParam == (IntPtr)keyValue && m.lParam != (IntPtr)1)
                {
                    return false;
                }
            }
            return true;
        }
    
        #endregion
    
    
        #region P-Invoke
    
        const uint PM_NOREMOVE = 0x0000;
        const uint WM_CHAR = 258;
    
        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool PeekMessage(out NativeMessage lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);
    
        [StructLayout(LayoutKind.Sequential)]
        public struct NativeMessage
        {
            public IntPtr handle;
            public uint msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }
    
        #endregion
    }
