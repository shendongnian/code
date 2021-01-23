    public class OtherProgram
    {
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);            
        
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message); 
        
        public static readonly int WM_SHOWFIRSTINSTANCE =
            WinApi.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", "ANY_UNIQUE_STING");
                    
               
        public static void Main()
        {
            //public const int HWND_BROADCAST = 0xffff;
            PostMessage(
			(IntPtr)WinApi.HWND_BROADCAST, 
			WM_SHOWFIRSTINSTANCE,
			IntPtr.Zero,
			IntPtr.Zero);
        }
    }	
