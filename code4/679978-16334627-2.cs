        protected void yourGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               // Find your controls
               CheckBoxList yourChkBoxList = e.Row.FindControl("yourChkBoxListName") as CheckBoxList;
               ObjectDataSource odsTemp=e.Row.FindControl("yourDataSourceName") as ObjectDataSource;
         if (odsTemp !=null)
            {
               odsTemp.SelectParameters[0].DefaultValue = yourGridView.DataKeys[e.Row.RowIndex][0].ToString();
               yourGridView.DataBind();
            }
         }
        }
