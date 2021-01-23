    private void view_RowStyle(object sender, RowStyleEventArgs e)
    {
      var view = sender as GridView;
      if (view != null)
      {
        int lastRowIndex = (view.GridControl.DataSource as BindingSource).Count;
        if (view.IsRowVisible(lastRowIndex) == RowVisibleState.Visible)
        {
          //go get more rows.
        }
      }
    }
