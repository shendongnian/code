        private bool _working = false;
        private void view_RowStyle(object sender, RowStyleEventArgs e)
        {
          if(_working) return;
         
          var view = sender as GridView;
          if (view != null)
          {
            int lastRowIndex = (view.GridControl.DataSource as BindingSource).Count;
            if (view.IsRowVisible(lastRowIndex) == RowVisibleState.Visible)
            {
              _working = true;
              //go get more rows.
              _working = false;
            }
          }
        }
