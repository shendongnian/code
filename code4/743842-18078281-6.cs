     class Program
    {
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, ref COPYDATASTRUCT lParam);
        [DllImport("user32", CharSet=CharSet.Auto)]
        private static extern IntPtr FindWindow(string className, string windowName);
        static void Main(string[] args)
        {         
            while (true)
            {
                //require entering 3 elements of a Color: RED GREEN BLUE (each one is maximum at 255 and minimum at 0
                Console.Write("Enter color R G B: ");//should enter something like 100 200 50
                string[] s = Console.ReadLine().Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                Color colorToBeSent = Color.FromArgb(int.Parse(s[0]),int.Parse(s[1]), int.Parse(s[2]));
                try {
                  int cbSize = Marshal.SizeOf(typeof(Color));
                  IntPtr lpData = Marshal.AllocHGlobal(cbSize);                
                  Marshal.StructureToPtr(colorToBeSent, lpData, true);
                  if (hwnd == IntPtr.Zero)
                    hwnd = FindWindow(null, "Winforms Application");
                  if(hwnd != IntPtr.Zero){
                    COPYDATASTRUCT data = new COPYDATASTRUCT();
                    data.dwData = new IntPtr(123456);//This is like the key to notify the receiver that this is sent from your Console.
                    //Because many applications can send WM_COPYDATA to your winforms application.
                    data.lpData = lpData;
                    data.cbSize = cbSize;                    
                                        
                    SendMessage(hwnd, 0x4a, IntPtr.Zero, ref data);//WM_COPYDATA = 0x4a
                  }
                }
                finally {
                  Marshal.FreeHGlobal(lpData);                
                }
            }
        }
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbSize;
            public IntPtr lpData;
        }    
