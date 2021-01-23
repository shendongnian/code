    public void SetSelection(string colName, bool sel)
    {
        foreach(UltraGridRow r in grid.Rows)
        {
            if(r.IsDataRow == true)
               r.Cells[colName].Value = sel;
        }
    }
