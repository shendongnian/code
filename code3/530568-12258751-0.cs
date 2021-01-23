       protected void gv_RowDataBound(object sender, GridViewEditEventArgs e)
        {
         if (e.Row.RowType == DataControlRowType.DataRow)
          {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                  DropDownList ddList= (DropDownList)e.Row.FindControl("drpcategory1");
                  //bind dropdownlist
                  DataTable dt = con.GetData("Select category_name from category");
                  ddList.DataSource = dt;
                  ddList.DataTextField = "category_name";
                  ddList.DataValueField = "category_name";
                  ddList.DataBind();
                  DataRowView dr = e.Row.DataItem as DataRowView;
                  ddList.SelectedItem.Text = dr["category_name"].ToString();
                }
           }
        }
        
        protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
          gv.EditIndex = e.NewEditIndex;
          gridviewBind();// your gridview binding function
        }
