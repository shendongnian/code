    protected void Page_PreRender(object sender, EventArgs e)
    {
      if(!Page.IsPostBack)
     {
       if (ViewState["id"] != null)
          {
              dropdownlist1 .SelectedValue = ViewState["id"].ToString();
           }
      }
    }
