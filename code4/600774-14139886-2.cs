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
                trayMenu.MenuItems.Add("Exit");
                trayMenu.MenuItems.Add("Show", FormShow);
                trayIcon = new NotifyIcon();
                trayIcon.Text = "MyTrayApp";
                trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
                trayIcon.ContextMenu = trayMenu;
                trayIcon.Visible = true;
                TopMost = true;
                Resize += new EventHandler(Form1_Resize);
            }
    
            void Form1_Resize(object sender, EventArgs e)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    ShowInTaskbar = false;
                    Hide();
                    trayIcon.Visible = true;
                }
            }
    
            void FormShow(object sender, EventArgs e)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    WindowState = FormWindowState.Normal;
                }
                ShowInTaskbar = true;
                Show();
                Focus();
                trayIcon.Visible = false;
            }
    
            protected override void OnLoad(EventArgs e)
            {
                Visible = false;
                ShowInTaskbar = false;
            }
        }
