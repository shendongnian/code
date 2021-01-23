    protected void gridView1_RowCreated(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            RadioButton rdbAnswer = (RadioButton)e.Row.FindControl("rdbAnswer");
            if(YourCondition)
            {
                // Remove event handler
                rdbAnswer.CheckedChanged -= new EventHandler(rdbAnswer_CheckedChanged);
                // maybe you also want to set rdbAnswer.AutoPostBack="false" to prevent the postback
            }
        }
    }
