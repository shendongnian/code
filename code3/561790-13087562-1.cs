        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find the label with the temp name and assign it
                string tempName = (e.Row.FindControl("Label1") as Label).Value;
                DropDownList ddl = e.Row.FindControl("DropDownList1") as DropDownList;
                ddl.DataTextField = "RunDate";
                ddl.DataValueField = "TempID";
                ddl.DataSource = runDates[tempName];
                ddl.DataBind();
            }
        }
