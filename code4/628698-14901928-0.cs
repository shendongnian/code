    <asp:GridView runat="server" ID="GridView1" 
       AutoGenerateColumns="False" OnPreRender="GridView_PreRender">
        <Columns>
            <asp:BoundField DataField="LastName" HeaderText="LastName" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
        </Columns>
    </asp:GridView>
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var users = new List<User>
                {
                    new User {FirstName = "John", LastName = "Doe"},
                    new User {FirstName = "Marry", LastName = "Newton"},
                    new User {FirstName = "Joe", LastName = "Black"}
                };
    
            GridView1.DataSource = users;
            GridView1.DataBind();
        }
    }
    
    protected void GridView_PreRender(object sender, EventArgs e)
    {
        foreach (DataControlField column in GridView1.Columns)
            if (column.HeaderText == "FirstName")
                column.Visible = false;
    }
