    TableCell tbCell1 = new TableCell();
    CheckBox cb12 = new CheckBox();
    tbCell1.Controls.Add(cb12);
    Gridview1.HeaderRow.Cells.Add(tbCell1);
    
    foreach (GridViewRow gvr in Gridview1.Rows)
    {
         TableCell tbCell = new TableCell();
         CheckBox cb1 = new CheckBox();
         tbCell.Controls.Add(cb1);
         gvr.Cells.Add(tbCell);
    }
