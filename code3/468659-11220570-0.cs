    //Use this if you want to control the ReadOnly setting while loading itself
    grid.QueryCellInfo += new GridQueryCellInfoEventHandler(grid_QueryCellInfo);
     
    void grid_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
    {
        if (e.Style.CellValue.Equals("YYY"))
        {
            e.Style.ReadOnly = true;
        }
    }
     
    //Use this if you want to Validate while Editing
    grid.CurrentCellValidating += new CurrentCellValidatingEventHandler(grid_CurrentCellValidating);
     
    void grid_CurrentCellValidating(object sender, CurrentCellValidatingEventArgs e)
    {
        //Will deactive the cell and new value will be discarded
        //e.NewValue = e.OldValue;
     
        //To remain in Edit mode without committing the vlaue
        e.Cancel = true;
    }
