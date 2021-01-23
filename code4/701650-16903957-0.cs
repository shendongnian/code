    public FolderMonitorApplicationContext()
    {
        this.monitor =  new Monitor();
        notifyIcon = new NotifyIcon();
        using (var stream = Assembly.GetExecutingAssembly()
            .GetManifestResourceStream("<project namespace>.<folder path>" + "filename.ico"))
        {
            notifyIcon.Icon = new Icon(stream);
        }
        notifyIcon.Text = "Folder Monitor";
        notifyIcon.Visible = true;
        contextMenu = new ContextMenuStrip();
        openMonitor = new ToolStripMenuItem();
        exitApplication = new ToolStripMenuItem();
        notifyIcon.ContextMenuStrip = contextMenu;
        notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
        openMonitor.Text = "Open";
        openMonitor.Click += new EventHandler(OpenMonitor_Click);
        contextMenu.Items.Add(openMonitor);
        exitApplication.Text = "Exit..";
        exitApplication.Click += new EventHandler(ExitApplication_Click);
        contextMenu.Items.Add(exitApplication);
    }
