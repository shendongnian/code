    #include <windows.h>
    #using <System.dll>
    
    using namespace System;
    using namespace System::Diagnostics;
    using namespace System::ComponentModel;
    
    // get window handle from part of window title
    public static IntPtr WinGetHandle(string wName)
    {
        IntPtr hwnd = IntPtr.Zero;
        foreach (Process pList in Process.GetProcesses())
        {
            if (pList.MainWindowTitle.Contains(wName))
            {
                hWnd = pList.MainWindowHandle;
                return hWnd;
            }
        }
        return hWnd;
    }
    
    // get window handle from exact window title
    [DllImport("user32.dll")]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
    public IntPtr GetHandleWindow(string title)
    {
        return FindWindow(null, title);
    } 
