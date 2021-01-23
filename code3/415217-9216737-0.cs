    static class Program
    {
       [STAThread]
       static void Main()
       {
          // Standard infrastructure code
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
 
          // Create a context menu and add item(s) to it
          ContextMenu mnu = new ContextMenu();
          MenuItem mnuExit = new MenuItem("E&xit");
          mnu.MenuItems.Add(mnuExit);
          mnuExit.Click += mnuExit_Click);
 
          // Create the NotifyIcon
          NotifyIcon ni = new NotifyIcon();
          ni.Icon = new Icon(GetType(), "icon.ico");
          ni.Text = "Email Notifier";
          ni.ContextMenu = mnu;
          ni.Visible = true;
 
          // Run the application
          Application.Run();
  
          // Before exiting, remove the NotifyIcon from the taskbar
          ni.Visible = false;
       }
 
       private static void mnuExit_Click(object Sender, EventArgs e)
       {
          Application.Exit();
       }
    }
