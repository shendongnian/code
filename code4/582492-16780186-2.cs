     private void Form1_FormClosing(object sender, FormClosingEventArgs e)
     {
         if (e.CloseReason == CloseReason.UserClosing)
         {
              myNotifyIcon.Visible = true;
              this.Hide();
              e.Cancel = true;
         }
     }
    
