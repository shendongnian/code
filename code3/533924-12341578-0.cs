    [DllImport ("user32.dll")] public static extern IntPtr FindWindow  (String sClassName, String sAppName);
    [DllImport ("user32.dll")] public static extern int    SendMessage (IntPtr hWnd, uint Msg, int wParam, int lParam);
        Timer t;
        public Form1 ()
        {
            InitializeComponent ();
            t=new Timer ();
            t.Interval=100;
            t.Tick+=delegate
            {
                IntPtr w=FindWindow (null, "Message box title");
                if (w!=null) SendMessage (w, 0x0112, 0xF060, 0);
            };
            t.Start ();
        }
