    private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
      switch (e.Column.Header)
      {
        case "ServerID":
          e.Column.Header = "Server";
          break;
        case "EventID":
          e.Column.Header = "Event";
          break;   
        default:
          e.Cancel = true;
          break;
      }
    }
