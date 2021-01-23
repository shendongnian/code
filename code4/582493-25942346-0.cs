       namespace MinimizeTrayNotification
         {
          public partial class Form1 : Form
           {
        public Form1()
        {
            InitializeComponent();
        }
        private void MinimzedTray()
        {
            notifyIcon1.Visible = true;
            notifyIcon1.Icon = SystemIcons.Application;
            
            notifyIcon1.BalloonTipText = "Minimized";
            notifyIcon1.BalloonTipTitle = "Your Application is Running in BackGround";
            notifyIcon1.ShowBalloonTip(500);
        }
        private void MaxmizedFromTray()
        {
            notifyIcon1.Visible = true;
            notifyIcon1.BalloonTipText = "Maximized";
            notifyIcon1.BalloonTipTitle = "Application is Running in Foreground";
            notifyIcon1.ShowBalloonTip(500);
            
        }
        
        
        private void Form1_Resize(object sender, EventArgs e)
        {
            if(FormWindowState.Minimized==this.WindowState)
            {
            MinimzedTray();
            }
          else  if (FormWindowState.Normal == this.WindowState)
            {
                
                MaxmizedFromTray();
            }
            }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Form1 frm = new Form1();
            frm.Show();
            MaxmizedFromTray();
                
        }
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.Hide();
                
            }
           
        }
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.BalloonTipText = "Normal";
            notifyIcon1.ShowBalloonTip(500);
        }
     }
   }
