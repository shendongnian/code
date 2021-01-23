     private void FormMain_Deactivate(object sender, EventArgs e)
     {
         this.Hide();
     }
      private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
     {
       if (e.Button == MouseButtons.Left && !this.isVisible)
       {
             this.Show();
             this.Activate();
       }
     }
