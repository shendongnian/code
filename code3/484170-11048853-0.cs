    GridViewRow row = GameSearchGrid.SelectedRow;
    GridView gv = (GridView)row.Parent.Parent;
    
    int colIndex = -1;
    for (int i = 0; i < gv.Columns.Count; i++)
    {
        if (gv.Columns[i].HeaderText == "SKU")
        {
            colIndex = i;
            break;
        }
    }
    
    // handle case when correct column was not found
    
    string skuCellValue = row.Cells[colIndex].Text;
