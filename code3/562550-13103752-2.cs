    private void Form1_Load(object sender, EventArgs e)
    {
        Image ContextMenuStripItemImages = Image.FromFile(@"D:\Resources\International\Picrofo_Logo.png"); //Set the image from the path provided
        NotifyIcon trayIcon;
        ContextMenuStrip trayMenu;
        trayMenu = new ContextMenuStrip();
        trayMenu.Items.Add("Login", ContextMenuStripItemImages).Click += new EventHandler(Login_Click); //Create a new item in the context menu strip and link its Click event with Login_Click
        trayMenu.Items.Add("LogOut", ContextMenuStripItemImages).Click += new EventHandler(LogOut_Click); //Create a new item in the context menu strip and link its Click event with LogOut_Click
        trayIcon = new NotifyIcon();
        trayIcon.ContextMenuStrip = trayMenu; //Set the ContextMenuStrip of trayIcon to trayMenu
    }
    
    private void Login_Click(object sender, EventArgs e)
    {
        //Do something when Login is clicked
    }
    
    private void LogOut_Click(object sender, EventArgs e)
    {
        //Do something when LogOut is clicked
    }
