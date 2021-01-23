    class Program 
    {
        public static ContextMenu menu;
        public static MenuItem mnuExit;
        public static NotifyIcon notificationIcon;
        static void Main(string[] args)
        {
            Thread notifyThread = new Thread(
                delegate()
                {
                    menu = new ContextMenu();
                    mnuExit = new MenuItem("Exit");
                    menu.MenuItems.Add(0, mnuExit);
                    notificationIcon = new NotifyIcon()
                    {
                        Icon = Properties.Resources.Services,
                        ContextMenu = menu,
                        Text = "Main"
                    };
                    mnuExit.Click += new EventHandler(mnuExit_Click);
                    notificationIcon.Visible = true;
                    Application.Run();
                }
            );
            notifyThread.Start();
            Console.ReadLine();          
        }
        static void mnuExit_Click(object sender, EventArgs e)
        {
            notificationIcon.Dispose();
            Application.Exit();
        }
    }
