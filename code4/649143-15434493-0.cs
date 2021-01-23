    private boolean bFormCloseFlag = false;
    
    private void Connect_Click(object sender, EventArgs e)
    {
        try
        {
             orcl.connect(userID.Text, Password.Text, comboTNS.Text);
    
             if (orcl.ifHasRows("select dbclass from setupdbversion where dbclass='SECURITY' and rownum=1"))
             {//my stuff
                 bFormCloseFlag = true;
                 this.Close();
             }
    
         }
         catch (Exception ex)
         {
              MessageBox.Show(ex.Message.ToString());
         };
    }
    
    
    private void SecConnForm_FormClosing_1(object sender, FormClosingEventArgs e)
    {   
         if (bFormCloseFlag = false)
         {
            MessageBox.Show(sender.ToString());
            if (e.CloseReason == CloseReason.UserClosing)
            {
              MessageBox.Show(sender.ToString());
              if (string.Equals((sender as Form).Name, @"SecConnForm")) //it doesn't work as in any cases the      sender is my form, not a button (when i click on button of course)
              {
                   if (MessageBox.Show(this, "Really exit?", "Closing...",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                           == DialogResult.Cancel) 
                       e.Cancel = true;
                   else
                       Application.Exit();
    
              }
              else
              {
                   //other stuff goes..
              }
           }
         }
    }
