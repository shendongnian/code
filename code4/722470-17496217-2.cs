    public void Page_Load(object sender, EventArgs e)
    {
        string theValue1 = list.Items.Last()["URL"].ToString();
        SPSite site = new SPSite("http://maindt/sites/dev");
        SPWeb web = site.OpenWeb();
        SPList list = web.Lists["Links"];
    }
