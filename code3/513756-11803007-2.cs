    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //This is where you would get your cultures out of an xml or database
            //I'm using a non-dynamic list to make a simple representation
            List<string> cultures = new List<string>() { "de-DE", "en-US", "en-UK" };
            repCultures.DataSource = cultures;
            repCultures.DataBind();
        }
    }
    
    protected void repCultures_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            string culture = e.Item.DataItem as string;
            HyperLink hypCulture = e.Item.FindControl("hypCulture") as HyperLink;
            hypCulture.Text = culture;
            hypCulture.NavigateUrl = string.Format("~/yourpage.aspx?culture={0}", culture);
        }
    }
