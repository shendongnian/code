    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(this.ExplicitTitle))
        {
            this.MasterPageTitle.Text = "My Site | " + Page.Title;
        }
        else
        {
            this.MasterPageTitle.Text = this.ExplicitTitle;
        }
    }
