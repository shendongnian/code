    public partial class Form1 : Form
        {
            private NotifyIcon trayIcon;
            private ContextMenu trayMenu;
    
            public Form1()
            {
                InitializeComponent();
    
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Name = "Program";
    
                trayMenu = new ContextMenu();
                trayMenu.MenuItems.Add("Exit", OnExit);
                trayMenu.MenuItems.Add("Show", OnShow);
                trayIcon = new NotifyIcon();
                trayIcon.Text = "MyTrayApp";
                trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
                trayIcon.ContextMenu = trayMenu;
                trayIcon.Visible = true;
            }
    
            protected override void OnLoad(EventArgs e)
            {
                Visible = false;
                ShowInTaskbar = false;
            }
    
            protected override void OnResize(EventArgs e)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    ShowInTaskbar = false;
                    Hide();
                }
            }
    
            private void OnExit(object sender, EventArgs e)
            {
                Application.Exit();
            }
    
            private void OnShow(object sender, EventArgs e)
            {
                TopMost = true;
                ShowInTaskbar = true;
                Show();
            }
        }
