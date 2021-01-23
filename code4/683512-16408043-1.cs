    <style type="text/css">
        .green, .yellow { border-radius: 10px; width: 20px; height: 20px;} 
        .green { background: green; }
        .yellow { background: yellow; }
    </style>
    <asp:GridView runat="server" ID="GridView1" OnDataBound="GridView1_DataBound"
        AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                    <asp:Panel runat="server" ID="CirclePanel">
                    </asp:Panel>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var table = new DataTable();
            table.Columns.Add(new DataColumn
                {
                    DataType = Type.GetType("System.Int32"),
                    ColumnName = "ID"
                });
            table.Columns.Add(new DataColumn
                {
                    DataType = Type.GetType("System.Int32"),
                    ColumnName = "ParentID"
                });
    
            for (int i = 0; i <= 2; i++)
            {
                var row = table.NewRow();
                row["ID"] = i + 100;
                row["ParentID"] = i;
                table.Rows.Add(row);
            }
    
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
    }
    
    public void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var row = ((DataRowView)e.Row.DataItem).Row;
            int parentID = row.Field<int>("ParentID");
            var panel = (Panel)e.Row.FindControl("CirclePanel");
            panel.CssClass = parentID == 1 ? "yellow" : "green";
        }
    }
