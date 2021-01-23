     private void OnDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {           
                    var lc = grid.SelectedItem as LoanComparison;
                    if (lc != null) _viewModel.Open(lc);
                    
                }
            }
        }
