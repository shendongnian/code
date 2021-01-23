    [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        static extern bool PostMessage(
            IntPtr hWnd, 
            uint msg, 
            int wParam, 
            int lParam
            );
        const uint WM_KEYDOWN = 0x100;
        const int WM_a = 0x41;
        const int WM_b = 0x42;
        const int WM_c = 0x43;
        static void Main(string[] args)
        {
            //using Process.GetProcessesByName to get the handle we want  
            Process[] p = Process.GetProcessesByName("notepad");  
            IntPtr pHandle = p[0].MainWindowHandle;  
            //will write "abc" in the open Notepad window
            PostMessage(pHandle, WM_KEYDOWN, WM_a, 0);
            PostMessage(pHandle, WM_KEYDOWN, WM_b, 0);
            PostMessage(pHandle, WM_KEYDOWN, WM_c, 0);
        }
