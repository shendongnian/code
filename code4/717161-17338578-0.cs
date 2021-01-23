    public void ContextMenuOpening(object sender, CancelEventArgs e) {
    
      Point mousePosition = myListView.PointToClient(Control.MousePosition);
      ListViewHitTestInfo hit = myListView.HitTest(mousePosition);
    
      e.Cancel = hit.Item == null;
    }
