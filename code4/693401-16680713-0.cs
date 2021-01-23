    <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" 
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="EmpID" DataField="EmpID" />
            <asp:TemplateField HeaderText="EmpName" >
                <ItemTemplate>
                    <asp:Label runat="server" ID="EmpNameLabel" 
                        Text='<%# Eval("EmpName") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="UnitID" DataField="UnitID" />
            <asp:TemplateField HeaderText="UnitName" >
                <ItemTemplate>
                    <asp:Label runat="server" ID="UnitNameLabel" 
                        Text='<%# Eval("UnitName") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    
    public class Employee
    {
        public int EmpID { get; set; }  
        public string EmpName  { get; set; }  
        public int UnitID  { get; set; }
        public string UnitName { get; set; }  
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = new List<Employee>
        {
        new Employee { EmpID = 1, EmpName = "One", UnitID = 100, UnitName = "One hundred"},
        new Employee { EmpID = 2, EmpName = "Two", UnitID = 200, UnitName = "Two hundred"},
        new Employee { EmpID = 3, EmpName = "Three", UnitID = 300, UnitName = "Three hundred"},
        new Employee { EmpID = 4, EmpName = "Four", UnitID = 400, UnitName = "Four hundred"}
        };
        GridView1.DataBind();
    }
    
    
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var employee = e.Row.DataItem as Employee;
            var empNameLabel = e.Row.FindControl("EmpNameLabel") as Label;
            var unitNameLabel = e.Row.FindControl("UnitNameLabel") as Label;
    
            if (employee.UnitID == 200)
            {
                empNameLabel.Visible = false;
                unitNameLabel.Visible = false;
            }
        }
    }
