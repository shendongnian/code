        public MyForm()
        {
            InitializeComponent();
            NotifyIcon trayIcon = new NotifyIcon()
            {
                Icon = new Icon(@"C:\Temp\MyIcon.ico"),
                BalloonTipText = "Open Me!",
                Visible = true
            };
            trayIcon.DoubleClick += new EventHandler(trayIcon_DoubleClick);
        }
        public void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Normal;
        }
