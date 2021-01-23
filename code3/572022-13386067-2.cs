    public void AddCheckBoxColumn(DataGridView grid, EventHandler<DataGridViewCellEventArgs> handler, bool threeState)
    {
       grid.Columns.Add(new DataGridViewEventCheckBoxColumn(handler, threeState));
    }
    
