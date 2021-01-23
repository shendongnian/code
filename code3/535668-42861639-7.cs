    protected void Page_PreRenderComplete(object sender, EventArgs e)
    {
        this.FormatGridviewRows();
    }
    private void FormatGridviewRows()
    {
        foreach (GridViewRow row in this.GridView1.Rows)
        {
            // Don't attempt changes on header / select / etc. Only Datarow
            if (row.RowType != DataControlRowType.DataRow) continue;
            // At least make sure everything has the default class
            row.CssClass = "gridViewRow";
            // Don't affect the first row
            if (row.DataItemIndex <= 0) continue; 
            if (row.RowState == DataControlRowState.Normal || row.RowState == (DataControlRowState.Normal ^ DataControlRowState.Edit))
            {
                row.CssClass = !this.cbForceOverride.Checked 
                    ? "gridViewRow" 
                    : "gridViewRow gridViewRowDisabled";
            }
            if (row.RowState == DataControlRowState.Alternate || row.RowState == (DataControlRowState.Alternate ^ DataControlRowState.Edit))
            {
                row.CssClass = !this.cbForceOverride.Checked
                    ? "gridViewAltRow"
                    : "gridViewAltRow gridViewAltRowDisabled";
            }
        }
    }
