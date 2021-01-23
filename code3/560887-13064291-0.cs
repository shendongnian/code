    protected void gridView1_RowCreated(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            RadioButton rdbAnswer = (RadioButton)e.Row.FindControl("rdbAnswer");
            // Remove event handler:
            if(YourCondition)
                rdbAnswer.OnCheckedChanged -= new EventHandler(rdbAnswer_CheckedChanged);
        }
    }
