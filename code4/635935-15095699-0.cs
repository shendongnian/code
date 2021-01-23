    <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
    <asp:Button runat="server" ID="AddButton" OnClick="AddButton_Click" Text="Add" />
    
    private List<int> _controlIds;
    
    private List<int> ControlIds
    {
        get
        {
            if (_controlIds == null)
            {
                if (ViewState["ControlIds"] != null)
                    _controlIds = (List<int>)ViewState["ControlIds"];
                else
                    _controlIds = new List<int>();
            }
            return _controlIds;
        }
        set { ViewState["ControlIds"] = value; }
    }
    
    private List<string> DataSource
    {
        get { return new List<string> { "One", "Two", "Three" }; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            var dataSource = DataSource;
    
            foreach (int id in ControlIds)
            {
                var ddl = new DropDownList();
                ddl.ID = id.ToString();
    
                foreach (var data in dataSource)
                    ddl.Items.Add(new ListItem(data));
    
                PlaceHolder1.Controls.Add(ddl);
            }
        }
    }
    
    protected void AddButton_Click(object sender, EventArgs e)
    {
        var dataSource = DataSource;
        for (int i = 0; i < 3; i++)
        {
            var reqs = ControlIds;
            int id = ControlIds.Count + 1;
    
            reqs.Add(id);
            ControlIds = reqs;
    
            var ddl = new DropDownList();
            ddl.ID = id.ToString();
    
            foreach (var data in dataSource)
                ddl.Items.Add(new ListItem(data));
    
            PlaceHolder1.Controls.Add(ddl);
        }
    }
