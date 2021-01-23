    private void SetupMinimize()
    {
        this.components = new System.ComponentModel.Container();
        this.contextMenu1 = new System.Windows.Forms.ContextMenu();
        this.menuItem1 = new System.Windows.Forms.MenuItem();
        // Initialize contextMenu1
        this.contextMenu1.MenuItems.AddRange(
                    new System.Windows.Forms.MenuItem[] { this.menuItem1 });
        // Initialize menuItem1
        this.menuItem1.Index = 0;
        this.menuItem1.Text = "E&xit";
        this.menuItem1.Click += new EventHandler(menuItem1_Click);
        // Set up how the form should be displayed.
        width = this.ActualWidth;
        height = this.ActualHeight;
        // Create the NotifyIcon.
        this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
        // The Icon property sets the icon that will appear
        // in the systray for this application.
        notifyIcon1.Icon = new System.Drawing.Icon(@"Images\tag.ico");
        // The ContextMenu property sets the menu that will
        // appear when the systray icon is right clicked.
        notifyIcon1.ContextMenu = this.contextMenu1;
        // The Text property sets the text that will be displayed,
        // in a tooltip, when the mouse hovers over the systray icon.
        notifyIcon1.Text = "App (Ninja Mode)";
        notifyIcon1.Visible = true;
        notifyIcon1.BalloonTipText = "App is hiding.";
        notifyIcon1.BalloonTipTitle = "App!";
        // Handle the DoubleClick event to activate the form.
        //notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
        notifyIcon1.Click += new EventHandler(notifyIcon1_Click);
        
    }
