    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<string> source = new List<string>();
            source.Add("entry1");
            source.Add("entry2");
            source.Add("entry3");
            Session["source"] = source;
            gvEntries.DataSource = source;
            gvEntries.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        List<string> source = (List<string>)Session["source"];
        source.Add(txtNewEntry.Text);
        gvEntries.DataSource = source;
        gvEntries.DataBind();
    }
