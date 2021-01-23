    private void FormLoad(object sender, EventArgs e)
    {
             this.txtDir.KeyUp += new System.Windows.Forms.KeyEventHandler(CheckKeys);
    }
    private void CheckKeys(object sender, System.Windows.Forms.KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
      if (sender == txtDir && txtDir.Text != "" && System.IO.Directory.Exists(txtDir.Text))
      {
          btnBrowse_Click(this, e);
      }
      }           
    }
