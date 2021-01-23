    private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
       
          if(MessageBox.Show("Do you really want to exit?", "My Application",
             MessageBoxButtons.YesNo) ==  DialogResult.No){
           
                    // SET TO TRUE, SO CLOSING OF THE MAIN FORM, 
                    // SO THE APP ITSELF IS BLOCKED
                    e.Cancel = true;            
          }
       }
    }
