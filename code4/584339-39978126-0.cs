    protected override void Render(HtmlTextWriter writer)
    {
        foreach (GridViewRow row in Results.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                row.Attributes["onmouseover"] = "this.style.cursor='pointer';";
                row.CssClass = "rowHover";
                row.ToolTip = "Click row to view person's history";
                row.Attributes.Add("onclick", this.ClientScript.GetPostBackClientHyperlink(this.Results,"Select$" & r.RowIndex , true));
            }
        }
        base.Render(writer);
    }
