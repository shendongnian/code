    private void Save_Click(object sender, EventArgs e)
    {
      if (!string.IsNullorEmpty(txtFilePath.Text))
      {
        MessageBox.Show("Please enter new path");
        txtFilePath.Focus();
        return;
      }
      else
        string path = txtFilePath.Text;
          if (!File.Exists(path))
            {
               ..... Your rest code
