    using System.Runtime.InteropServices;
    using System.Diagnostics;
    public class GetNotePadLocation
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);
        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
        }
        public static void NotePadLocation()
        {
            Process[] processes = Process.GetProcessesByName("notepad");
            Process lol = processes[0];
            IntPtr ptr = lol.MainWindowHandle;
            Rect NotepadRect = new Rect();
            GetWindowRect(ptr, ref NotepadRect);
        }
    }
