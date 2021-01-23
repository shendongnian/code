    private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
       if(MessageBox.Show("Are you sure your want to quit?", "My Application", MessageBoxButtons.YesNo) ==  DialogResult.No)
       {
          e.Cancel = true;
       }
    }
