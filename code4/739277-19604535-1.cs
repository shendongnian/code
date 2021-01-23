    protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            bool isQuantitative = ((CheckBox)e.Row.FindControl("cb1")).Checked;
    
            if (isQuantitative)
            {
                ((textBox)e.Row.FindControl("myTextboxID")).Visible = true;
                ((DropDownList)e.Row.FindControl("myDdlistID")).Visible = false;
            }
            else
            {
                ((textBox)e.Row.FindControl("myTextboxID")).Visible = false;
                ((DropDownList)e.Row.FindControl("myDdlistID")).Visible = true;
            }
        }
    }
