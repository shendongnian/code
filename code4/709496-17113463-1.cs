    var list = countryRegionList.Select(o => new { o.CountryCode }).Distinct();
    ddlCountry_Billing.DataSource = list;
    ddlCountry_Billing.DataTextField = "CountryCode";
    ddlCountry_Billing.DataValueField = "CountryCode";
    ddlCountry_Billing.DataBind();
