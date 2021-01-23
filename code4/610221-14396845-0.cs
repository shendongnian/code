        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                DropDownList1.Items.Add(new ListItem("Name", "jsh"));
                DropDownList1.Items.Add(new ListItem("hhh", "sds"));
            }
        }    
