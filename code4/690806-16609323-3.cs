     MyForm_FormClosing(object sender, FormClosingEventArgs e)
     {
         // NOTE, you don't want to abort closing when Windows shutdown, right?
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
