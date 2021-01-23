    public void Page_Load(object sender, EventArgs e)
    {
        IEnumerable<string> theValues1 = list.Items.Select(i => i["URL"].ToString());
        SPSite site = new SPSite("http://maindt/sites/dev");
        SPWeb web = site.OpenWeb();
        SPList list = web.Lists["Links"];
    }
