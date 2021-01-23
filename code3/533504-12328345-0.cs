     class StringHolder 
     {
          public StringHolder(string displayText) { DisplayText = displayText; }
          public string DisplayText { get; set;}
     }
    IList<StringHolder> WrapStrings(IList<string> strings)
    {
        return strings.Select(it => new StringHolder(it)).ToList());
              
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DropDownList drop = (DropDownList)e.Row.FindControl("folders");
        drop.DataTextField = "DisplayText";
        drop.DataSource   = WrapStrings(list);
        drop.DataBind(); 
    }
    
