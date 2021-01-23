     protected void ddlDetails_DataBound(object sender, EventArgs e)
    {
        DropDownList ddl = sender as DropDownList;
        if(ddl!=null)
      {
        foreach (ListItem li in ddl.Items)
        {
          li.Attributes["title"] = li.Text;
        } 
      }
    }
