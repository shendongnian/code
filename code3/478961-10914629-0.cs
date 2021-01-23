    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label countryNameLabel = (Label)e.Row.FindControl("CountryNameLabel");
                    countryNameLabel.ToolTip = countryNameToolTip(countryNameLabel.Text);
                    countryNameLabel.Text = countryNameDisplay(countryNameLabel.Text);
                }
            }
    
    protected string countryNameDisplay(string key)
            {
                CustomerBusinessProvider business = new CustomerBusinessProvider();
                string country = business.CountryName(key);
                country = key + "-" + country;
                if (country.Length > 10)
                {
                    country = country.Substring(0, 10) + "...";
                }
                return country;
            }
            protected string countryNameToolTip(string key)
            {
                CustomerBusinessProvider business = new CustomerBusinessProvider();
                return business.CountryName(key);
            }
