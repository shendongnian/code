Move the logic on ListBox_Region_SelectedIndexChanged to a separated method and call it from page_load when postback is false.
	protected void Page_Load(object sender, EventArgs e)
	{
	    if(!Page.IsPostBack)
		{
		      // Bind ListBox_Region and set the first value as selected
			  ...
			  //
			  BindAreaList();
		}
	}
    protected void ListBox_Region_SelectedIndexChanged(object sender, EventArgs e)
    {
		BindAreaList();
    }
	
	protected void BindAreaList()
	{
        this.ListBox_Area.Items.Clear();
        string selectedRegion = ListBox_Region.SelectedValue;
        var query = (from s in DBContext.areas
                     where s.arregion == selectedRegion
                     select s);
        ListBox_Area.DataSource = query;
        ListBox_Area.DataBind();	 
	}
