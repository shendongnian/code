    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {          
        if (!AnyChildAlive())
           return;
        if (MessageBox.Show("Do you want to save before exit?", "Closing",
               MessageBoxButtons.YesNo, 
               MessageBoxIcon.Information) != DialogResult.Yes)
           return;
                
       MessageBox.Show("To Do saved.", "Status",
            MessageBoxButtons.OK, MessageBoxIcon.Information);     
            
    }
