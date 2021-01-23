    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnAccessType = (HiddenField)e.Row.FindControl("hdnAccessType");
                int accessType = int.Parse(hdnAccessType.Value.ToString());
                CheckBox chkReadOnly = (CheckBox)e.Row.FindControl("chkReadOnly");
                CheckBox chkModify = (CheckBox)e.Row.FindControl("chkModify");
                switch (accessType)
                {
                    case 1:
                        chkReadOnly.Checked = true;
                        break;
                    case 2:
                        chkModify.Checked = true;
                        break;
                }
            }
        }
