    using System;
    using System.Runtime.InteropServices;
    
    namespace IconKiller
    {
        class Program
        {
            /// Import the needed Windows-API functions:
            // ... for enumerating all running desktop windows
            [DllImport("user32.dll")]
            static extern bool EnumWindows(EnumDesktopWindowsDelegate lpfn, IntPtr lParam);
            private delegate bool EnumDesktopWindowsDelegate(IntPtr hWnd, int lParam);
    
            // ... for loading an icon
            [DllImport("user32.dll")]
            static extern IntPtr LoadImage(IntPtr hInst, string lpsz, uint uType, int cxDesired, int cyDesired, uint fuLoad);
    
            // ... for sending messages to other windows
            [DllImport("user32.dll")]
            static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);
    
    
            /// Setup global variables
            // Pointer to empty icon used to replace all other application icons
            static IntPtr m_pIcon = IntPtr.Zero;
    
            // Windows API standard values
            const int IMAGE_ICON = 1;
            const int LR_LOADFROMFILE = 0x10;
            const int WM_SETICON = 0x80;
            const int ICON_SMALL = 0;
    
            static void Main(string[] args)
            {
                // Load the empty icon 
                string strIconFilePath = @"C:\clicknrun.ico";
                m_pIcon = LoadImage(IntPtr.Zero, strIconFilePath, IMAGE_ICON, 16, 16, LR_LOADFROMFILE);
    
                // Setup the break condition for the loop
                int counter = 0;
                int max = 10 * 60 * 60;
    
                // Loop to catch new opened windows            
                while (counter < max)
                {
                    // enumerate all desktop windows
                    EnumWindows((EnumDesktopWindowsCallback), IntPtr.Zero);
                    counter++;
                    System.Threading.Thread.Sleep(100);
                }
    
                // ... then restart application
                Console.WriteLine("done");
                Console.ReadLine();
            }
    
            private static bool EnumDesktopWindowsCallback(IntPtr hWnd, int lParam)
            {
                // Replace window icon
                SendMessage(hWnd, WM_SETICON, ICON_SMALL, m_pIcon);
    
                return true;
            }
        }
    }
