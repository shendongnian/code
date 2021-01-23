    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    
    namespace ShowToolTip
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void btBallonToolTip_Click(object sender, EventArgs e)
            {
                ShowBalloonTip();
                this.Hide();
            }
    
            private void ShowBalloonTip()
            {
                Container bpcomponents = new Container();
                ContextMenu contextMenu1 = new ContextMenu();
    
                MenuItem runMenu = new MenuItem();
                runMenu.Index = 1;
                runMenu.Text = "Run...";
                runMenu.Click += new EventHandler(runMenu_Click);
    
                MenuItem breakMenu = new MenuItem();
                breakMenu.Index = 2;
                breakMenu.Text = "-------------";
    
                MenuItem exitMenu = new MenuItem();
                exitMenu.Index = 3;
                exitMenu.Text = "E&xit";
    
                exitMenu.Click += new EventHandler(exitMenu_Click);
    
                // Initialize contextMenu1
                contextMenu1.MenuItems.AddRange(
                            new System.Windows.Forms.MenuItem[] { runMenu, breakMenu, exitMenu });
    
                // Initialize menuItem1
    
                this.ClientSize = new System.Drawing.Size(0, 0);
                this.Text = "Ballon Tootip Example";
    
                // Create the NotifyIcon.
                NotifyIcon notifyIcon = new NotifyIcon(bpcomponents);
    
                // The Icon property sets the icon that will appear
                // in the systray for this application.
                string iconPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\setup-icon.ico";
                notifyIcon.Icon = new Icon(iconPath);
    
                // The ContextMenu property sets the menu that will
                // appear when the systray icon is right clicked.
                notifyIcon.ContextMenu = contextMenu1;
    
                notifyIcon.Visible = true;
    
                // The Text property sets the text that will be displayed,
                // in a tooltip, when the mouse hovers over the systray icon.
                notifyIcon.Text = "Morgan Tech Space BallonTip Running...";
                notifyIcon.BalloonTipText = "Morgan Tech Space BallonTip Running...";
                notifyIcon.BalloonTipTitle = "Morgan Tech Space";
                notifyIcon.ShowBalloonTip(1000);
            }
    
            void exitMenu_Click(object sender, EventArgs e)
            {
                this.Close();
            }
    
            void runMenu_Click(object sender, EventArgs e)
            {
                MessageBox.Show("BallonTip is Running....");
            }
        }
    }
