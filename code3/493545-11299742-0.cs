    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // rush in all controls of a row
            foreach (var control in e.Row.Controls)
            {
                // check if the control is a label
                if (control is Label)
                {
                    // call your function and cast the control to a Label
                    HighLight_Hours((Label) control);
                }
            }
        }
    }
