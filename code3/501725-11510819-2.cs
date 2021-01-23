     private void grid_Loaded(object sender, RoutedEventArgs e)
            {
                SortDirectionHelper(sender as DataGrid);
            }
    
            public void SortDirectionHelper(DataGrid dg)
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
            }
