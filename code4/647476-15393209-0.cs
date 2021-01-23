    <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
    <asp:LinkButton ID="addButton" runat="server" OnClick="btnAdd_Click">Add TextBox</asp:LinkButton>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" /><br/>
    Posted Results: <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    
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
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            foreach (int id in ControlIds)
            {
                var textbox = new TextBox();
                textbox.ID = id.ToString();
    
                PlaceHolder1.Controls.Add(textbox);
            }
        }
    }
    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var reqs = ControlIds;
        int id = ControlIds.Count + 1;
    
        reqs.Add(id);
        ControlIds = reqs;
    
        var textbox = new TextBox();
        textbox.ID = id.ToString();
    
        PlaceHolder1.Controls.Add(textbox);
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        var ids = ControlIds;
        foreach (var id in ids)
        {
            var textbox = (TextBox)PlaceHolder1.FindControl(id.ToString());
            Label1.Text += textbox.Text + ", ";
        }
    }
