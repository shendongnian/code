     private enum WindowShowStyle : uint
        {  // find more info at http://stackoverflow.com/a/8210120/1245420
            Hide = 0, ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            ShowNormalNoActvate = 4, Show = 5, Minimize = 6, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern System.IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern System.IntPtr FindWindowByCaption(System.IntPtr ZeroOnly, string lpWindowName);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(System.IntPtr hWnd, WindowShowStyle nCmdShow);
        DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public App()
        {
            this.Deactivated += App_Deactivated;
            this.Activated += App_Activated;
            timer.Tick += delegate
            {
                Application.Current.MainWindow.Activate();
                System.IntPtr hWndCharmBar = FindWindowByCaption(System.IntPtr.Zero, "Charm Bar");
                                ShowWindow(hWndCharmBar, 0);
            };
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
        }
        void App_Activated(object sender, EventArgs e)
        {
            timer.Stop();
        }
       
        void App_Deactivated(object sender, EventArgs e)
        {
            timer.Start();
        }
