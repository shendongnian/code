    private void cmbModules_SelectedValueChanged(object sender, EventArgs e)
    {
      var cmb = sender as ComboBox;
      if (cmb != null)
      {
        dynamic item = (dynamic)cmb.SelectedItem;
        string fname = item.Filename;
        string fpath = item.FilePath;
      }
    }
