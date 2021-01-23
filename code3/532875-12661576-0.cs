    private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) 
            { 
                this.Show(); 
                this.WindowState = FormWindowState.Normal; 
            }
            else 
            {
                this.WindowState = FormWindowState.Minimized; 
                this.Hide(); 
            }
            this.Activate();
        }
