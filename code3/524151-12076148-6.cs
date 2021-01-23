    // Aspx Code
    <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" 
        AllowPaging="True" 
         onrowediting="GridView1_RowEditing" onrowupdating="GridView1_RowUpdating" onrowcancelingedit="GridView1_RowCancelingEdit" 
        >        
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="City" HeaderText="Name" />
            <asp:CommandField ShowEditButton ="true" ShowCancelButton="true"  ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
    // Aspx Code Behind
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) // If you not place this check then you will get the old values because GridView in Bind on every postback
        {
            BindGrid();
        }
    }
    private void BindGrid() // function for binding gridview
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name");
        dt.Columns.Add("City");
        DataRow r = dt.NewRow();
        r[0] = "Name 1";
        r[1] = "City 1";
        DataRow r1 = dt.NewRow();
        r1[0] = "Name 2";
        r1[1] = "City 2";
        dt.Rows.Add(r);
        dt.Rows.Add(r1);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex; // setting new index
        BindGrid();
    }
   
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string newvalue = ((TextBox)row.Cells[0].Controls[0]).Text;
         GridView1.EditIndex = -1; // Again reset
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1; // reseting grid view
        BindGrid();
    }
