    <asp:ListView runat="server" ID="ListView1">
        <ItemTemplate>
            <%# Eval("Name") %>, 
            <%# Eval("Email") %>, 
            <%# Eval("Phone") %><br />
        </ItemTemplate>
    </asp:ListView>
    <br/>
    <asp:GridView ID="GridView1" AutoGenerateColumns="True" runat="server" />
    
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        var collections = new List<User>
            {
                new User {Name = "Jon Doe", Email = "john@doe.com", Phone = "123-123-1234"},
                new User {Name = "Marry Doe", Email = "marry@doe.com", Phone = "456-456-4567"},
                new User {Name = "Eric Newton", Email = "eric@newton.com", Phone = "789-789-7890"},
            };
    
        ListView1.DataSource = collections;
        ListView1.DataBind();
    
        GridView1.DataSource = collections;
        GridView1.DataBind();
    }
