    private void copyToolStripMenuItem_Click(object sender, EventArgs e)
    {
      CopyClipboard(sender);
    }
    private void CopyClipboard(object sender)
    {
      var grid = (DataGridView)sender;
      DataObject d = grid.GetClipboardContent();
      Clipboard.SetDataObject(d);
    }
    private void pasteCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var item = (ToolStripMenuItem)sender;
      ToolStripMenuItem t = (ToolStripMenuItem)sender;
      ContextMenuStrip s = (ContextMenuStrip)t.Owner;
      var grid = (DataGridView)s.SourceControl;
      // Pulling the backend datatable just to enhance the example.
      // Going Live, the consumer of the "grid" will do the extraction.
      BindingSource bs = (BindingSource)grid.DataSource;
      DataTable dt = (DataTable)bs.DataSource;
      PasteClipboard(grid, dt);
    }
