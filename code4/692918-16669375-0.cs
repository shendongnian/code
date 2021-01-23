    protected void gvDogBok_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           ((HyperLink)e.Row.Controls[1].Controls[1]).Attribute.Add("onclick", "window.opener.location =userProfile.aspx?ID="+    ((YourType)e.Row.DataItem).ID+"; window.close();";
         }
    }
