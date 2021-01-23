    YourGridData(DataGridView grid)
    {
        int numCells = grid.SelectedCells.Count;
            foreach (DataGridViewCell cell in grid.SelectedCells)
            {
                if (cell.Value != null)
                    //Do Something
                else
                    //try or catch null here    
            }
    }
