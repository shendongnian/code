    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    namespace Chrome_Windows
    {
        class Program
        {
            [DllImport("user32.dll")]
            private static extern bool EnumThreadWindows(uint dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);
    
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        
            [DllImport("User32", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int GetWindowText(IntPtr windowHandle, StringBuilder stringBuilder, int nMaxCount);
    
            [DllImport("user32.dll", EntryPoint = "GetWindowTextLength", SetLastError = true)]
            internal static extern int GetWindowTextLength(IntPtr hwnd);
    
            private static List<IntPtr> windowList;
            private static string _className;
            private static StringBuilder apiResult = new StringBuilder(256); //256 Is max class name length.
            private delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);
    
            static void Main(string[] args) 
            {
                List<IntPtr> ChromeWindows = WindowsFinder("Chrome_WidgetWin_1", "chrome");
                foreach (IntPtr windowHandle in ChromeWindows) 
                {
                    int length = GetWindowTextLength(windowHandle);
                    StringBuilder sb = new StringBuilder(length + 1);
                    GetWindowText(windowHandle, sb, sb.Capacity);
                    Console.WriteLine(sb.ToString());
                }
            }
            
            private static List<IntPtr> WindowsFinder(string className, string process)
            {
                _className = className;
                windowList = new List<IntPtr>();
    
                Process[] chromeList = Process.GetProcessesByName(process);
            	if (chromeList.Length > 0)
            	{
                    foreach (Process chrome in chromeList)
                    {
                    	if (chrome.MainWindowHandle != IntPtr.Zero)
                    	{
                            foreach (ProcessThread thread in chrome.Threads)
                            {
                            	EnumThreadWindows((uint)thread.Id, new EnumThreadDelegate(EnumThreadCallback), IntPtr.Zero);
                       	    }
                    	}
                    }
            	}
                return windowList;
            }
    
            static bool EnumThreadCallback(IntPtr hWnd, IntPtr lParam)
            {
                if (GetClassName(hWnd, apiResult, apiResult.Capacity) != 0)
                {
                    if (string.CompareOrdinal(apiResult.ToString(), _className) == 0)
                    {
                        windowList.Add(hWnd);
                    }
                }
                return true;
            }   
        }
    }
