    public int DataGridViewDeadSpaceWidth
    {
        get
        {
            int x = grid.Width;
            foreach (DataGridViewColumn column in grid.Columns)
                x -= column.Width;
    
            return x;
        }
    }
