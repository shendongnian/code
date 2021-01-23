    private void Form1_Load(object sender, EventArgs e)
    {
        NotifyIcon trayIcon;
        ContextMenuStrip trayMenu;
        trayMenu = new ContextMenuStrip();
        trayMenu.Items.Add("Login", Image.FromFile("ImageFile")).Click += new EventHandler(Login_Click);
        trayMenu.Items.Add("LogOut", Image.FromFile("ImageFile")).Click += new EventHandler(LogOut_Click);
        trayIcon = new NotifyIcon();
        trayIcon.ContextMenuStrip = trayMenu;
    }
    
    private void Login_Click(object sender, EventArgs e)
    {
        //Do something when Login is clicked
    }
    
    private void LogOut_Click(object sender, EventArgs e)
    {
        //Do something when LogOut is clicked
    }
