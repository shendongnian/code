    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            IList<ListItem> list = new List<ListItem>();
            list.Add(new ListItem(Resources.Site.OriginalStructure, "0"));
            list.Add(new ListItem("5", "5"));
            list.Add(new ListItem("10", "10"));
            list.Add(new ListItem("15", "15"));
            list.Add(new ListItem("20", "20"));
            list.Add(new ListItem("25", "25"));
        
            DropDownList1.DataSource = list;
            DropDownList1.DataTextField = "Text";
            DropDownList1.DataValueField = "Value";
            DropDownList1.DataBind();
        
            DropDownList2.DataSource = list;
            DropDownList2.DataTextField = "Text";
            DropDownList2.DataValueField = "Value";
            DropDownList2.DataBind(); 
        }   
    }  
