    private void ClientsEdit_Load(object sender, EventArgs e)
    {
      // loading stuff
      Binding ForenameBinding = new Binding("Text", dtClients, "Forename", true, DataSourceUpdateMode.OnPropertyChanged);
      ForenameBinding.BindingComplete += Table_BindingComplete;
      textForename.DataBindings.Add(ForenameBinding);
      // loading stuff
    }
    void Table_BindingComplete(object sender, BindingCompleteEventArgs e) {
      if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate)
        MessageBox.Show("Source Updated!");
    }
