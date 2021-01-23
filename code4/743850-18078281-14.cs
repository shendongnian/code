     class Program
    {
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, ref COPYDATASTRUCT lParam);
        [DllImport("user32", CharSet=CharSet.Auto)]
        private static extern IntPtr FindWindow(string className, string windowName);
        static void Main(string[] args)
        {    
            IntPtr hwnd = IntPtr.Zero;     
            while (true)
            {
                //require entering 3 elements of a Color: RED GREEN BLUE (each one is maximum at 255 and minimum at 0
                Console.Write("Enter color R G B: ");//should enter something like 100 200 50
                string[] s = Console.ReadLine().Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                Color colorToBeSent = Color.FromArgb(int.Parse(s[0]),int.Parse(s[1]), int.Parse(s[2]));
                COPYDATASTRUCT data = new COPYDATASTRUCT();
                try
                {
                    data.dwData = new IntPtr(123456);
                    data.cbSize = Marshal.SizeOf(typeof(Color));
                    data.lpData = Marshal.AllocHGlobal(data.cbSize);
                    Marshal.StructureToPtr(colorToBeSent, data.lpData, true);
                    if (hwnd == IntPtr.Zero)                              
                        hwnd = FindWindow(null, "Winforms Application");
                    if (hwnd != IntPtr.Zero)
                    {
                        SendMessage(hwnd, 0x4a, IntPtr.Zero, ref data);
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(data.lpData);
                }
            }
        }
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbSize;
            public IntPtr lpData;
        }    
