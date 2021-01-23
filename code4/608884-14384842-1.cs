        protected void ArrayDataView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlStrings");
                ddl.DataSource = (e.Row.DataItem as MyData).Amalgamation.Split(';');
            }       
        }
    }
