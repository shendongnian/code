     private void Form1_FormClosing(object sender, FormClosingEventArgs e)
     {
       if (e.CloseReason == CloseReason.UserClosing)
                {
                    mynotifyicon.Visible = true;
                    this.Hide();
                    e.Cancel = true;
                }
      }
    
