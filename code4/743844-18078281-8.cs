     //Must add reference to System.Drawing.dll
     //using namespaces:
     using System.Runtime.InteropServices;
     using System.Drawing;
     //..........................
     class Program {
        //This is used to send custom message to your Winforms
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);
        //This is used to find your winforms window
        [DllImport("user32", CharSet=CharSet.Auto)]
        private static extern IntPtr FindWindow(string className, string windowName);
        //This is used to register custom message so that it's ensured to be unique
        [DllImport("user32")]
        private static extern int RegisterWindowMessage(string msgName);
        //Our main method
        static void Main(string[] args)
        {
            int red = RegisterColorCode(Color.Red);
            int yellow = RegisterColorCode(Color.Yellow);
            while (true)
            {
                Console.Write("Enter color letter: ");
                string r = Console.ReadLine().ToLower();
                int msg = 0;
                if(r == "r") msg = red;
                if(r == "y") msg = yellow;
                //You can define more colors
                if (hwnd == IntPtr.Zero)                              
                    hwnd = FindWindow(null, "Winforms Application");
                if(hwnd != IntPtr.Zero) SetBackColor(msg);
            }
        }
        IntPtr hwnd = IntPtr.Zero;
        static int RegisterColorCode(Color c){
            return RegisterWindowMessage(c.ToString());
        }
        static void SetBackColor(int colorCode){
            SendMessage(hwnd, colorCode, IntPtr.Zero, IntPtr.Zero);
        }
    }
