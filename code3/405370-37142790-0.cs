    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    
    
    namespace ExcelChildWindowsTitle
    {
        class Program
        {
            static void Main(string[] args)
            {
                //XLMAIN/EXCELDESK/EXCEL7 as seen by Spy++ VS 2010 utility
                //IntPtr hWnd = WndSearcher.SearchForWindow("XLMAIN", "EXCEL7", "icui-20110331.xls", ref workbookTitle);
                //bool excelProofFound = WindowTitleSearcher.SearchForWindow("XLMAIN", "EXCEL7", "testfileopenedinEXCEL.xls", ref workbookTitle);
    
                bool excelProofFound = WindowTitleSearcher.SearchForWindow("file name here");
                if (excelProofFound)
                    Console.Write(":)))))))) Proof File opened in an Excel process;");
                else
                {
                    Console.Write(":|Proof File not found");
                }
            }
    
            public static class WindowTitleSearcher
            {
                private const string WINDOW_EXCEL7 = "XLMAIN";
                private const string CHILDWINDOW_XLMAIN = "EXCEL7";
    
                public static bool SearchForWindow(string title)
                {
                    SearchData sd = new SearchData { Wndclass = WINDOW_EXCEL7, ChildWndclass = CHILDWINDOW_XLMAIN, ChildTitle = title, WorkbookTitle = String.Empty };
                    EnumWindows(new EnumWindowsProc(EnumProc), ref sd);
                    return (int)sd.hWnd > 0;
                }
    
                private static bool EnumProc(IntPtr hWnd, ref SearchData data)
                {
                    const bool directOnly = false;
                    // Check classname and title 
                    // This is different from FindWindow() in that the code below allows partial matches
                    StringBuilder sb1 = new StringBuilder(1024);
                    GetClassName(hWnd, sb1, sb1.Capacity);
                    Debug.WriteLine(sb1.ToString());
                    if (sb1.ToString().StartsWith(data.Wndclass))
                    {
                        RecursiveEnumChildWindows(hWnd, directOnly, ref data);
                        if ((int)data.hWnd > 0)
                        {
                            // Found the wnd, halt enumeration
                            return false;
                        }
                    }
                    return true;
                }
    
                private static void RecursiveEnumChildWindows(IntPtr parentHwnd, bool directOnly, ref SearchData data)
                {
                    EnumChildWindows(parentHwnd, delegate(IntPtr hwnd, ref SearchData data1)
                    {
                        bool add = true;
                        if (directOnly)
                        {
                            add = GetParent(hwnd) == parentHwnd;
                        }
    
                        StringBuilder sb1 = new StringBuilder(1024);
                        GetClassName(hwnd, sb1, sb1.Capacity);
                        Debug.WriteLine("Child:" + sb1.ToString());
    
                        if (add)
                        {
    
                            if (sb1.ToString().StartsWith(data1.ChildWndclass))
                            {
                                sb1 = new StringBuilder(1024);
                                //Window Caption
                                GetWindowText(hwnd, sb1, sb1.Capacity);
                                if (sb1.ToString().Contains(data1.ChildTitle))
                                {
                                    data1.hWnd = hwnd;
                                    data1.WorkbookTitle = sb1.ToString();
                                    return false; // Found the wnd, halt enumeration
                                }
                            }
                        }
                        return true;
                    }, ref data);
                }
    
                private struct SearchData
                {
                    // You can put any vars in here...
                    public string Wndclass;
                    public string ChildWndclass;
                    public string ChildTitle;
                    public IntPtr hWnd;
                    public string WorkbookTitle;
                }
                # region Windows API declarations
                private delegate bool EnumWindowsProc(IntPtr hWnd, ref SearchData data);
    
                [DllImport("user32.dll")]
                [return: MarshalAs(UnmanagedType.Bool)]
                private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, ref SearchData data);
    
                //private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, [MarshalAsAttribute(UnmanagedType.Struct)] ref SearchData data);
    
                [DllImport("user32.dll")]
                [return: MarshalAs(UnmanagedType.Bool)]
                static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, ref SearchData data);
    
                [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
                public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
    
                [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
                private static extern IntPtr GetParent(IntPtr hWnd);
    
                [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
                public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
                # endregion
            }
        }
    }
    
    /////////////////////Work good on Windows 10 64 bit
