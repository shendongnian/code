    protected void gridView1_RowCreated(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            for(int i = 0; i < e.Row.Cells.Count; i++)
            {
                TableCell cell = e.Row.Cells[i];
                cell.ToolTip = "Click to filter by this value";
                string js = string.Format("var txt=document.getElementById('{0}');txt.value='{1} {2}';{3}"
                    , TxtFilter.ClientID, e.Row.RowIndex, i
                    , ClientScript.GetPostBackClientHyperlink(TxtFilter, null));
                cell.Attributes["onclick"] = js;
            }
        }
    }
  
