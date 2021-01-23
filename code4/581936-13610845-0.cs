    string tenant = (string)cmd.ExecuteScalar();
    conn.Close();
    if (tenant == "Y")
    //            ^ ^ make sure to change these to double-quotes
    {
        ((DropDownList)GridViewServer.FooterRow.FindControl("DropDownTenant")).Visible = true;
    }
    else
    {
        ((DropDownList)GridViewServer.FooterRow.FindControl("DropDownTenant")).Visible = false;
    }
