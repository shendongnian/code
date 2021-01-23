        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UnhookWindowsHookEx(int idHook);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);
        [StructLayout(LayoutKind.Sequential)]
        public class MouseStruct
        {
            public Point pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }
        
        public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam); 
        
        private int hHook;
        public const int WH_MOUSE_LL = 14;
        public static HookProc hProc;
        public int SetHook()                                        
        {
            hProc = new HookProc(MouseHookProc);
            hHook = SetWindowsHookEx(WH_MOUSE_LL, hProc, IntPtr.Zero, 0);
            return hHook;
        }
        public void UnHook()                                        
        {
            UnhookWindowsHookEx(hHook);
        }
        //callback function, invoked when there is an mouse event
        private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)              
        {
            var MyMouseStruct = (MouseStruct)Marshal.PtrToStructure(lParam, typeof(MouseStruct));
            if (nCode < 0)
            {
                return CallNextHookEx(hHook, nCode, wParam, lParam);    
            }
            else
            {
                switch wParam{
                    case (IntPtr)513:
                        //click
                        //do whatever you want
                    case (IntPtr)512:
                        //move
                    case (IntPtr)514:
                        //release
                    default:
                }
                Cursor.Position = MyMouseStruct.pt;
                //stop the event from passed to other windows.
                return 1;
            }
        }
