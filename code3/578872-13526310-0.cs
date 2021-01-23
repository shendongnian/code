    private void datagridview_CellValidated(object sender, CellValidatedEventArgs e)
    {
    
    if (e.ColumnIndex != 3)
        return;
    int nextRowIndex = e.RowIndex -1;
    try
    {
    
            if (nextRowIndex >=0 )
            {
                var valuesForcell = datagridview.Rows[e.RowIndex].Cells[3].Value.ToString();
                datagridview.Rows[nextRowIndex].Cells[2].Value = valuesForcell;
                datagridview.Rows[nextRowIndex].Cells[2].ReadOnly = true;
                datagridview.Rows[nextRowIndex].Cells[2].Style.ForeColor = Color.MediumVioletRed;
                datagridview.ClearSelection();
                datagridview.SelectionMode = GridViewSelectionMode.CellSelect;
                datagridview.Rows[nextRowIndex].Cells[3].BeginEdit();
    
            }
    
    }
    catch (Exception exception) { }
    
    
    } 
