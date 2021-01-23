    protected void gridView1_RowDataBound(object sender, GridViewEditEventArgs e)
    {
     if (e.Row.RowType == DataControlRowType.DataRow)
      {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
              DropDownList DdlCountry = (DropDownList)e.Row.FindControl("DdlCountry");
              // bind DropDown manually
              DdlCountry.DataSource = GetCountryDataSource();
              DdlCountry.DataTextField = "country_name";
              DdlCountry.DataValueField = "country_id";
              DdlCountry.DataBind();
              DataRowView dr = e.Row.DataItem as DataRowView;
              Ddlcountry.SelectedValue = value; // you can use e.Row.DataItem to get the value
            }
       }
    }
