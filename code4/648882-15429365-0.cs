    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Check if this is our Blank Row being databound, if so make the row invisible
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            if (((DataRowView)e.Row.DataItem)["CertificateNo"].ToString() == String.Empty) e.Row.Visible = false;
            //Check if is in edit mode
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                DropDownList DropDownListStatus = (DropDownList)e.Row.FindControl("DropDownListStatus");
                //Bind status data to dropdownlist
                DropDownListStatus.DataTextField = "Status";
                DropDownListStatus.DataValueField = "Status";
                DropDownListStatus.DataSource = RetrieveStatus();
                DropDownListStatus.DataBind();
                DataRowView dr = e.Row.DataItem as DataRowView;
                DropDownListStatus.SelectedValue = dr["Status"].ToString();
             }
            
        }
    }
