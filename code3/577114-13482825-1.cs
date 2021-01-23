    void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Get the current row's data
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            // Do your conversion
            var conv = int.Parse(rowView["currencyconvfactor"].ToString()); // Whatever conversion calculation you need to do.
            // Set the value of the control in the ItemTemplate
            Label lblConvValue= (Label)e.Row.FindControl("lblConvValue");
            lblConvValue.Text = conv.ToString(); 
        }
    }
