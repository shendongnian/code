    public NotifyIcon notifyIcon1 = new NotifyIcon();
    public ContextMenu contextMenu1 = new ContextMenu();
    
    public void createIconMenuStructure()
    {
       // Add menu items to context menu.
       contextMenu1.MenuItems.Add("&Open Application");
       contextMenu1.MenuItems.Add("S&uspend Application");
       contextMenu1.MenuItems.Add("E&xit");
    
       // Set properties of NotifyIcon component.
       notifyIcon1.Visible = true;
       notifyIcon1.Icon = new System.Drawing.Icon
          (System.Environment.GetFolderPath
          (System.Environment.SpecialFolder.Personal)
          + @"\Icon.ico");
       notifyIcon1.Text = "Right-click me!";
       notifyIcon1.ContextMenu = contextMenu1;
    }
