    namespace Win32
    {
        public class ShowWindowConsts
        {
            // Reference: http://msdn.microsoft.com/en-us/library/ms633548(VS.85).aspx
    
            /// <summary>
            /// Minimizes a window, even if the thread that owns the window is not responding. 
            /// This flag should only be used when minimizing windows from a different thread.
            /// </summary>
            public const int SW_FORCEMINIMIZE = 11;
    
            /// <summary>
            /// Hides the window and activates another window.
            /// </summary>
            public const int SW_HIDE = 0;
    
            /// <summary>
            /// Maximizes the specified window.
            /// </summary>
            public const int SW_MAXIMIZE = 3;
    
            /// <summary>
            /// Minimizes the specified window and activates the next top-level window in the Z order.
            /// </summary>
            public const int SW_MINIMIZE = 6;
    
            /// <summary>
            /// Activates and displays the window. 
            /// If the window is minimized or maximized, the system restores it to 
            /// its original size and position. 
            /// An application should specify this flag when restoring a minimized window.
            /// </summary>
            public const int SW_RESTORE = 9;
    
            /// <summary>
            /// Activates the window and displays it in its current size and position.
            /// </summary>
            public const int SW_SHOW = 5;
    
            /// <summary>
            /// Sets the show state based on the public const long SW_ value specified in 
            /// the STARTUPINFO structure passed to the CreateProcess function by 
            /// the program that started the application.
            /// </summary>
            public const int SW_SHOWDEFAULT = 10;
    
            /// <summary>
            /// Activates the window and displays it as a maximized window.
            /// </summary>
            public const int SW_SHOWMAXIMIZED = 3;
    
            /// <summary>
            /// Activates the window and displays it as a minimized window.
            /// </summary>
            public const int SW_SHOWMINIMIZED = 2;
    
            /// <summary>
            /// Displays the window as a minimized window. 
            /// This value is similar to public const long SW_SHOWMINIMIZED, 
            /// except the window is not activated.
            /// </summary>
            public const int SW_SHOWMINNOACTIVE = 7;
    
            /// <summary>
            /// Displays the window in its current size and position. 
            /// This value is similar to public const long SW_SHOW, except that the window is not activated.
            /// </summary>
            public const int SW_SHOWNA = 8;
    
            /// <summary>
            /// Displays a window in its most recent size and position. 
            /// This value is similar to public const long SW_SHOWNORMAL, 
            /// except that the window is not activated.
            /// </summary>
            public const int SW_SHOWNOACTIVATE = 4;
    
            public const int SW_SHOWNORMAL = 1;
        }
    }
