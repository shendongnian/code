     private void CaseGridView_DataLoaded(object sender, EventArgs e)
        {
            var grid = sender as RadGridView;
            if (grid != null)
            {
                grid.SelectedItem = vm.CurrentlySelectedItem;
                if (grid.SelectedItem != null)
                {
                    grid.ScrollIntoView(grid.SelectedItem);
                }
            }
        }
