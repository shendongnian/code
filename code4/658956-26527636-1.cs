    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GenerateCoaTree();
        }
    }
    <asp:TreeView ID="TreeViewCoa" runat="server">
        <DataBindings>
            <asp:TreeNodeBinding DataMember="System.Data.DataRowView" 
                TextField="COADescription" ValueField="AccountID" />
        </DataBindings>
    </asp:TreeView>
