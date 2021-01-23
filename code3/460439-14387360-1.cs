    public string ConnectionString { get; set; }
    private void promptForDataConnection()
    {
      DataConnectionDialog dataConnection = new DataConnectionDialog();
      DataConnectionConfiguration connectionConfiguration = new DataConnectionConfiguration(null);
      connectionConfiguration.LoadConfiguration(dataConnection);
      if (DataConnectionDialog.Show(dataConnection) == DialogResult.OK)
      {
        connectionConfiguration.SaveConfiguration(dataConnection);
        this.ConnectionString = dataConnection.ConnectionString;
      }
    }
