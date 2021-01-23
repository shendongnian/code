    protected void GridDepartment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label LabelCoachName = e.Row.FindControl("LabelCoachName") as Label;
            LabelCoachName.ToolTip = LabelCoachName.Text;
        }
    }
