    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using System.Text;
    using System.Globalization;
    
    namespace WindowsFormsApplication20
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                foreach (IntPtr handle in EnumerateProcessWindowHandles(Process.GetProcessesByName("explorer")[0].Id))
                {
                    SendMessage(handle, WM_SYSCOMMAND, SC_MINIMIZE, 0);
                }
            }
    
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
    
            static string GetDaClassName(IntPtr hWnd)
            {
                int nRet;
                StringBuilder ClassName = new StringBuilder(100);
                //Get the window class name
                nRet = GetClassName(hWnd, ClassName, ClassName.Capacity);
                if (nRet != 0)
                {
                    return ClassName.ToString();
                }
                else
                {
                    return null;
                }
            }
    
            delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);
    
            [DllImport("user32.dll")]
            static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);
    
            static IEnumerable<IntPtr> EnumerateProcessWindowHandles(int processID)
            {
                List<IntPtr> handles = new List<IntPtr>();
    
                EnumThreadDelegate addWindowHandle = delegate(IntPtr hWnd, IntPtr param)
                {
                    string className = GetDaClassName(hWnd);
    
                    switch (className)
                    {
                        case null:
                            break;
                        case "ExploreWClass":
                            handles.Add(hWnd);
                            break;
                        case "CabinetWClass":
                            handles.Add(hWnd);
                            break;
                        default:
                            break;
                    }
                    
                    return true;
                };
    
                foreach (ProcessThread thread in Process.GetProcessById(processID).Threads)
                    EnumThreadWindows(thread.Id, addWindowHandle, IntPtr.Zero);
    
                return handles;
            }
    
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);
    
            const int WM_SYSCOMMAND = 274;
            const int SC_MINIMIZE = 0xF020;
        }
    }
