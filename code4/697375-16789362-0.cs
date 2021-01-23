        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {               
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                RadioButtonList rbl = (DropDownList)e.Row.FindControl("rbLevel");
                // Query the DataSource & get the corresponding data....
                // ...
                // if Read -> then Select 0 else if Edit then Select 1...
                rbLevel.SelectedIndex = 0;
            }
        }
