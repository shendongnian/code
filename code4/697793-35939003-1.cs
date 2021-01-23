     private void yourForm_FormClosing(object sender, FormClosingEventArgs e)
     {
         if (MessageBox.Show("Want to exit from Application ?",  MessageBoxButtons.YesNo) == DialogResult.Yes)
         {
             //Environment.Exit(0);
             e.Cancel = false;
         }
         else
         {
             // your Code for Changes or anything you want to allow user changes etc.
             e.Cancel = true;    
         }    
    }
