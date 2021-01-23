    //file Win32Api.cs
        using System;
        using System.Runtime.InteropServices;
        using YourProjectNamespace.Hooks;
        
        namespace YourProjectNamespace
        {
            
            public delegate int keyboardHookProc(int code, int wParam, ref keyboardHookStruct lParam);
            /// <summary>
            ///     Pcursor info
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct PCURSORINFO
            {
                public Int32 Size;
                public Int32 Flags;
                public IntPtr Cursor;
                public POINTAPI ScreenPos;
            }
        
            /// <summary>
            ///     Point
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct POINTAPI
            {
                public int x;
                public int y;
            }
        
            /// <summary>
            ///     keyboard hook struct
            /// </summary>
            public struct keyboardHookStruct
            {
                public int dwExtraInfo;
                public int flags;
                public int scanCode;
                public int time;
                public int vkCode;
            }
        
            /// <summary>
            ///     Wrapper for windows 32 calls.
            /// </summary>
            public class Win32Api
            {
                public const Int32 CURSOR_SHOWING = 0x00000001;
                public const int WH_KEYBOARD_LL = 13;
                public const int WM_KEYDOWN = 0x100;
                public const int WM_KEYUP = 0x101;
                public const int WM_SYSKEYDOWN = 0x104;
                public const int WM_SYSKEYUP = 0x105;
        
                [DllImport("user32.dll")]
                public static extern bool GetCursorInfo(out PCURSORINFO cinfo);
        
                [DllImport("user32.dll")]
                public static extern bool DrawIcon(IntPtr hDC, int X, int Y, IntPtr hIcon);
        
                [DllImport("winmm.dll")]
                private static extern int mciSendString(string MciComando, string MciRetorno, int MciRetornoLeng, int CallBack);
        
                [DllImport("user32")]
                private static extern int GetKeyboardState(byte[] pbKeyState);
        
                [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
                private static extern short GetKeyState(int vKey);
        
                [DllImport("user32")]
                public static extern int ToAscii(
                    int uVirtKey,
                    int uScanCode,
                    byte[] lpbKeyState,
                    byte[] lpwTransKey,
                    int fuState);
        
                [DllImport("user32.dll", CharSet = CharSet.Auto,
                    CallingConvention = CallingConvention.StdCall)]
                public static extern int CallNextHookEx(
                    IntPtr idHook,
                    int nCode,
                    int wParam,
                    ref keyboardHookStruct lParam);
        
                [DllImport("user32.dll", CharSet = CharSet.Auto,
                    CallingConvention = CallingConvention.StdCall, SetLastError = true)]
                public static extern int UnhookWindowsHookEx(IntPtr idHook);
        
                [DllImport("user32.dll", CharSet = CharSet.Auto,
                    CallingConvention = CallingConvention.StdCall, SetLastError = true)]
                public static extern IntPtr SetWindowsHookEx(
                    int idHook,
                    keyboardHookProc lpfn,
                    IntPtr hMod,
                    int dwThreadId);
        
        
               
        
                [DllImport("kernel32.dll")]
                public static extern IntPtr LoadLibrary(string dllToLoad);
                
        
                //Constants
            } // class Win32
    
    
     **File GlobalKeyboardHook.cs**
    
    
        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Runtime.InteropServices;
        using System.Windows.Forms;
        using log4net;
        
        namespace ScreenRecorder.Hooks
        {
        
            public class GlobalKeyboardHook
            {
                private static readonly ILog log = LogManager.GetLogger(typeof (GlobalKeyboardHook).Name);
        
                const int WH_KEYBOARD_LL = 13;
                const int WM_KEYDOWN = 0x100;
                const int WM_KEYUP = 0x101;
                const int WM_SYSKEYDOWN = 0x104;
                const int WM_SYSKEYUP = 0x105;
        
                private static keyboardHookProc callbackDelegate;
        
        
                public List<Keys> HookedKeys = new List<Keys>();
                private IntPtr keyboardHook = IntPtr.Zero;
        
               
        
        
                /// <summary>
                public GlobalKeyboardHook()
                {
                    Hook();
                }
        
                ~GlobalKeyboardHook() {
                    Unhook();
                }
        
                public event KeyEventHandler KeyDown;
                public event KeyEventHandler KeyUp;
        
                
                public int HookProc(int nCode, int wParam, ref keyboardHookStruct lParam)
                {
                    if (nCode >= 0)
                    {
                        var key = (Keys) lParam.vkCode;
                        if (HookedKeys.Contains(key))
                        {
                            var kArgs = new KeyEventArgs(key);
                            if ((wParam == Win32Api.WM_KEYDOWN || wParam == Win32Api.WM_SYSKEYDOWN) && (KeyDown != null))
                            {
                                KeyDown(this, kArgs);
                            }
                            else if ((wParam == Win32Api.WM_KEYUP || wParam == Win32Api.WM_SYSKEYUP) && (KeyUp != null))
                            {
                                KeyUp(this, kArgs);
                            }
                            if (kArgs.Handled)
                                return 1;
                        }
                    }
                    return Win32Api.CallNextHookEx(keyboardHook, nCode, wParam, ref lParam);
                }
        
            
        
                public void Hook()
                {
                    // Create an instance of HookProc.
        
                    
                    //if (callbackDelegate != null) throw new InvalidOperationException("Multiple hooks are not allowed!");
                    IntPtr hInstance = Win32Api.LoadLibrary("User32");
                    callbackDelegate = new keyboardHookProc(HookProc);
                   
                    //install hook
                    keyboardHook = Win32Api.SetWindowsHookEx( Win32Api.WH_KEYBOARD_LL, callbackDelegate, hInstance, 0);
        
                    //If SetWindowsHookEx fails.
                    if (keyboardHook == IntPtr.Zero)
                    {
                        //Returns the error code returned by the last unmanaged function called using platform invoke that has the DllImportAttribute.SetLastError flag set. 
                        var errorCode = Marshal.GetLastWin32Error();
        
                        log.Error("Unable to install keyboard hook.", new Win32Exception(errorCode));
                    }
                }
        
                /// <summary>
                ///     Unsubscribe for keyboard hook
                /// </summary>
                public void Unhook()
                {
                    if (callbackDelegate == null) return;
                    
                   
        
                    if (keyboardHook != IntPtr.Zero)
                    {
                        //uninstall hook
                        var retKeyboard = Win32Api.UnhookWindowsHookEx(keyboardHook);
                        //reset invalid handle
                        keyboardHook = IntPtr.Zero;
                        //if failed and exception must be thrown
                        if (retKeyboard == 0)
                        {
                            //Returns the error code returned by the last unmanaged function called using platform invoke that has the DllImportAttribute.SetLastError flag set. 
                            var errorCode = Marshal.GetLastWin32Error();
                            //Initializes and throws a new instance of the Win32Exception class with the specified error. 
                            log.Error("Error while uninstalling keyboard hook", new Win32Exception(errorCode));
                        }
                    }
        
                    callbackDelegate = null;
                }
            }
        
          
        }
