    protected void Gridview1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            var row = (DataRowView) e.Row.DataItem;
            var CountryNameLabel = (Label) e.Row.FindControl("CountryNameLabel");
            String CorporateAddressCountry = (String) row["CorporateAddressCountry"];
            CountryNameLabel.Text = CorporateAddressCountry.Length <= 10 
                                   ? CorporateAddressCountry
                                   : CorporateAddressCountry.Substring(0, 10);
        }
    }
  
