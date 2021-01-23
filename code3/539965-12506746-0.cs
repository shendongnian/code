    if (e.KeyCode == Keys.Enter)
    {
       if (sender == txtDir && txtDir.Text != "" && System.IO.Directory.Exists(txtDir.Text))
       {
           e.Hanlde = true; //it will be close enter keydown handling at this time
           btnBrowse_Click(this, e);
       }
    }    
