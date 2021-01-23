    void Page_Load(object sender, EventArgs e) {
        service1.WebServiceLinks a1 = new service1.WebServiceLinks();
        LinkDisplay.DataSource = a1.GetLinks();
        LinkDisplay.DataBind();
    }
