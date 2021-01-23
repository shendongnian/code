    protected override void OnCellToolTipTextNeeded(DataGridViewCellToolTipTextNeededEventArgs e)
    {
        if((e.RowIndex >= 0) && (e.ColumnIndex >= 0))
        {
            // By setting this explicitly we can make the ToolTip show the           
            // entire length even though the content itself has not changed.
            e.ToolTipText = this[e.ColumnIndex, e.RowIndex].Value.ToString();
        }
        base.OnCellToolTipTextNeeded(e);
    }
