        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddlNames.Items.Add(new ListItem("A","A"));        
                ddlNames.Items.Add(new ListItem("B","B"));
            }
            
        }
