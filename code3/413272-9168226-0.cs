    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
            onload="DropDownList1_Load" >
        </asp:DropDownList>
    
    
    protected void DropDownList1_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            List<string> DDLlist = new List<string>();
            DDLlist.Add("Report");
            DDLlist.Add("News");
            DropDownList1.DataSource = DDLlist;
            DropDownList1.SelectedValue = "Report";
            DropDownList1.DataBind();
        }
