        [DllImport("user32.dll")]
        public static extern int FindWindow(string ClassName, string WindowName);
 
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
 
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;
 
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int HWND = FindWindow(null, "My Window");//window title
 
            SendMessage(HWND, WM_SYSCOMMAND, SC_CLOSE, 0);
        }
