     MyForm_FormClosing(object sender, FormClosingEventArgs e)
     {
         if(e.CloseReason == CloseReason.UserClosing)
         {
             if (MessageBox.Show("Are you sure you want to exit?", "Confirmation", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == 
                                DialogResult.No)
             {
                  e.Cancel = true;
             }
        }
     }
