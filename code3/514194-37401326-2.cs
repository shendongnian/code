    private void backgroundworker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
       try
       {
           //Write what you want to do
       }
       catch (Exception ex)
       {
           MessageBox.Show("Error:\n\n" + ex.Message, "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
       }
    }
