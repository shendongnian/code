    <script type="text/javascript">
        function showMessage(id) {
            alert('You have selected row: ' + id);
        }
    </script>        
    <asp:GridView runat="server" ID="gv_instruments" 
        OnRowDataBound="gv_instruments_RowDataBound"
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" />
            <asp:BoundField HeaderText="FirstName" DataField="FirstName" />
            <asp:BoundField HeaderText="LastName" DataField="LastName" />
            <asp:TemplateField HeaderText="Click Me">
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="txt_partNumbers">
                    </asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var collection = new List<User>()
                {
                    new User {Id = 1, FirstName = "John", LastName = "Doe"},
                    new User {Id = 2, FirstName = "Marry", LastName = "Doe"},
                    new User {Id = 3, FirstName = "David", LastName = "Newton"},
                };
    
            gv_instruments.DataSource = collection;
            gv_instruments.DataBind();
        }
    }
    
    public void gv_instruments_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var txtBox1 = (TextBox) e.Row.FindControl("txt_partNumbers");
            if (txtBox1 != null)
            {
                txtBox1.Attributes.Add("onclick", 
                  string.Format("showMessage('{0}')", e.Row.RowIndex));
            }
        }
    }
