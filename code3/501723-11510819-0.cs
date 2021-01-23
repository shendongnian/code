     class ExDataGrid : DataGrid
        {
            bool isFirstRow = true;
    
            protected override void OnLoadingRow(DataGridRowEventArgs e)
            {
                base.OnLoadingRow(e);
                if (isFirstRow)
                    SortDirectionHelper(this);
            }
    
            private void SortDirectionHelper(DataGrid dg)
            {
                var tmp = dg.Items.SortDescriptions;
    
                foreach (SortDescription sd in tmp)
                {
                    var col = dg.Columns.Where(x => (((Binding)x.ClipboardContentBinding).Path.Path == sd.PropertyName)).FirstOrDefault();
                    if (col != null)
                    {
                        col.SortDirection = sd.Direction;
                    }
                }
    
                isFirstRow = false;
            }
        }
