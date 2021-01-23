    private enum ActionType
    {
        CellRightClick,
        CellDoubleClick
        // add as you need them
    }    
    private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewColumn selectedColumn = this.dgv[e.ColumnIndex, e.RowIndex].OwningColumn;
            this.PerformActionOnColumn(ActionType.CellDoubleClick, selectedColumn.Name);
        }
    }
    private void PerformActionOnColumn(ActionType action, string columnName)
    {
        switch (columnName)
        {
            case "col_One":
                switch (action)
                {
                    case ActionType.CellRightClick:
                        // right click actions for col_One
                        break;
                    case ActionType.CellDoubleClick:
                        // double click actions for col_One
                        break;
                }
                break;
            case "col_Two":
                switch (action)
                {
                    case ActionType.CellRightClick:
                        // right click actions for col_Two
                        break;
                    case ActionType.CellDoubleClick:
                        // double click actions for col_Two
                        break;
                }
                break;
        }
    }
