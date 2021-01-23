    public MainForm(bool WasUpdated = false) {
        InitializeComponent();
        if(!WasUpdated) {
            instance = this;
            Icon = DesktopInterface.MainForm.Properties.Resources.favicon;
            tabPages = DesktopInterface.MainForm.Setup.TabSetup.GetTabs();
            foreach(var page in tabPages) {
                tabControl1.TabPages.Add( page );
            }
        } else {
            restartTimer.Start();
        }
    }
