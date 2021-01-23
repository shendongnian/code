        private void dg_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            // dg is the DataGrid in the view
            object o = dg.ItemContainerGenerator.ItemFromContainer(e.Row);
            // myColl is the observable collection
            if (myColl.Contains(o)) { /* item in the collection was updated! */  }
        }
