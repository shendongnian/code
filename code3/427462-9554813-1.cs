    void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (row.RowType == DataControlRowType.DataRow){
            e.Row.Visible = SomeCondition;
        }
    }
