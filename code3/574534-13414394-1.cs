     protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            using (DataClassesDataContext dc = new DataClassesDataContext())
            {
                var v = (from s in dc.t_employees select s).ToList();
                rptPdfList.DataSource = v;
                rptPdfList.DataBind();
            }
        }
    }
    protected void rptPdfList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem) return;
        Label lblName = (Label)e.Item.FindControl("lblName");
        switch (e.CommandName)
        {
            case "LoadDoc":
                //xpdfHolder.Attributes.Add("src", "PDF/" + lblName.Text);
                lblTest.Text = "test";
                lblName.Text = "oops";
                break;
        }
    }
