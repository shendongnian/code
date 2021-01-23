    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            var data = new XmlDataSource();
            data.DataFile = Server.MapPath("~/input.xml");
            treevCourses.DataSource = data;
            treevCourses.DataBind();
            treevCourses.Attributes.Add("onclick", "fireCheckChanged()");
        }
    }
    protected void check_changed(object sender, TreeNodeEventArgs e)
    {
        string clickedNode = e.Node.Text;
        System.Diagnostics.Debugger.Break();
    }
