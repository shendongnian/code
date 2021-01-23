    using System;
    
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace CatchMouseMove
    {
        class InterceptMouse
        {
            const int INPUT_MOUSE = 0;
            const int MOUSEEVENTF_WHEEL = 0x0800;
            const int WH_MOUSE_LL = 14; 
    
    
            private static LowLevelMouseProc _proc = HookCallback;
            private static IntPtr _hookID = IntPtr.Zero;
    
            public static void Main()
            {
                _hookID = SetHook(_proc);
    
                if (_hookID == null)
                {
                    MessageBox.Show("SetWindowsHookEx Failed");
                    return;
                }
                Application.Run();
                UnhookWindowsHookEx(_hookID);
            }
    
            private static IntPtr SetHook(LowLevelMouseProc proc)
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_MOUSE_LL, proc,
                        GetModuleHandle(curModule.ModuleName), 0);
                }
            }
    
            private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);
    
            private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
                int xPos = 0;
                int yPos = 0;
                if (nCode >= 0 && MouseMessages.WM_MOUSEMOVE == (MouseMessages)wParam)
                {    
                    xPos = GET_X_LPARAM(lParam); 
                    yPos = GET_Y_LPARAM(lParam);
                    //do stuff with xPos and yPos
                }
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }
    
    
            private enum MouseMessages
            {
                WM_MOUSEMOVE = 0x0200
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct POINT
            {
                public int x;
                public int y;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct MSLLHOOKSTRUCT
            {
                public POINT pt;
                public int mouseData;
                public int flags;
                public int time;
                public IntPtr dwExtraInfo;
            }
    
            public struct INPUT
            {
                public int type;
                public MOUSEINPUT mi;
            }
    
            [StructLayout(LayoutKind.Sequential)]
            public struct MOUSEINPUT
            {
                public int dx;
                public int dy;
                public int mouseData;
                public uint dwFlags;
                public int time;
                public int dwExtraInfo;
            }
    
    
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook,
                LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
                IntPtr wParam, IntPtr lParam);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
    
        }
    
    }
