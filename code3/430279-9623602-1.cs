        private static NotifyIcon _notifyIcon;
        //you can call this public function
        internal static void ShowBalloonTip(Icon icon)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerAsync(icon);
        }
        private static void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Show(e);
            Thread.Sleep(2000); //meaning it displays for 2 seconds
            DisposeOff();
        }
        private static void Show(DoWorkEventArgs e)
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = (Icon)e.Argument;
             _notifyIcon.BalloonTipTitle = "Environment file is opened";
            _notifyIcon.BalloonTipText = "Press alt+tab to switch between environment files";
            _notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            _notifyIcon.Visible = true;
            _notifyIcon.ShowBalloonTip(2000); //sadly doesnt work for me :(
        }
        private static void DisposeOff()
        {
            if (_notifyIcon == null)
                return;
            _notifyIcon.Dispose();
            _notifyIcon = null;
        }
