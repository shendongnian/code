        private void BindCollection(IEnumerable collection)
        {
            // keep current index
            GridView view = MyXtraGrid.Views[0] as GridView;
            int index = 0;
            int topVisibleIndex = 0;
            if (view != null)
            {
                index = view.FocusedRowHandle;
                topVisibleIndex = view.TopRowIndex;
            }
            
            MyXtraGrid.BeginUpdate();
            MyXtraGrid.DataSource = collection;
            MyXtraGrid.RefreshDataSource();
            if (view != null)
            {
                view.FocusedRowHandle = index;
                view.TopRowIndex = topVisibleIndex;
            }
            MyXtraGrid.EndUpdate();
        }
