    private void FilterQuotationsCommandExecute(GridViewFilteredEventArgs e)
        {
            var grid = (RadGridView) e.Source; // we casted the Source to Grid
            var item = grid.SelectedItem;      // we can access grid's selected items
        }
