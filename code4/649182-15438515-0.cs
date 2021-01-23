    private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
      var contextMenu = (sender as ContextMenuStrip);
      if (contextMenu != null) {
        var sourceControl = contextMenu.SourceControl;
        contextMenuStrip1.Items.Clear();
        //contextMenuStrip1.Items.Add(...);
      }
    }
