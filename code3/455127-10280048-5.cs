    using System;
    using System.Runtime.InteropServices;
    
    namespace Sandbox
    {
        class Program
        {
            [DllImport("user32.dll")]
            static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
    
            [DllImport("user32.dll")]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    
            [DllImport("user32.dll")]
            static extern IntPtr FindWindowEx(IntPtr hWnd, string lpClassName, string lpWindowName, string lParam);
    
            public const Int32 WM_CHAR = 0x0102;
            public const Int32 WM_KEYDOWN = 0x0100;
            public const Int32 WM_KEYUP = 0x0101;
            public const Int32 VK_RETURN = 0x0D;
    
            public const string windowName = "Untitled - Notepad";
    
            static void Main(string[] args)
            {
                Console.WriteLine($"Finding {windowName}");
                var hwndWindowNotepad = FindWindow(null, "Untitled - Notepad");
    
                if (hwndWindowNotepad != 0)
                {
                    // Find the target Edit window within Notepad.
                    var hwndWindowTarget = FindWindowEx(hwndWindowNotepad, null, "Edit", null);
                    if (hwndWindowTarget != 0)
                    {
                        Console.WriteLine($"Sending Char to {windowName}");
                        PostMessage(hwndWindowTarget, WM_CHAR, 'G', 0);
                    }
                }
            }
        }
    }
