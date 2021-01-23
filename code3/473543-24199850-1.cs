    private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
          // Display a MsgBox asking the user if he is sure to close
          if(MessageBox.Show("Are you sure you want to close?", "My Application", MessageBoxButtons.YesNo) 
             == DialogResult.Yes)
          {
             // Cancel the Closing event from closing the form.
             e.Cancel = false;
             // e.Cancel = true would close the window
          }
    }
