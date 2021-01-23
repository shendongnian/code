    public void AddCheckBoxColumn(DataGridView grid, EventHandler<DataGridViewCellEventArgs> handler, bool threeState)
    {
       DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn(threeState);
       column.CellTemplate = new DataGridViewEventCheckBoxCell(handler, threeState);
       grid.Columns.Add(column);
    }
