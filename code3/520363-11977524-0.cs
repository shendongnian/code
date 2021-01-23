    void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onContextMenu ", ClientScript.GetPostBackEventReference(GridView1, "Select$" + e.Row.RowIndex.ToString()) + "; return false;");
        }
    }
    
    protected override void Render(HtmlTextWriter writer)
    {
        for (int index = 0; index < GridView1.Rows.Count; index++)
        {
            ClientScript.RegisterForEventValidation(GridView1.UniqueID, "Select$" + index.ToString());
        }
    
        base.Render(writer);
    }
