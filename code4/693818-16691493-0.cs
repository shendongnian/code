    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
            return;
        Functions.username = "1"; // This is just to get rid of my login screen for testing puposes
        DropDownList1.Items.Clear();
        Functions.moduledatelister();
        for (int i = 0; i <= Functions.moduledatelist.Count-1; i++) {
            DropDownList1.Items.Add(Functions.moduledatelist.ElementAt(i));
        }
    }
