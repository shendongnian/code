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
    
    public void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var item = e.Row.DataItem as SomeObject;
            var panel = (Panel)e.Row.FindControl("CirclePanel");
    
            if (item.ParentID == 1)
            {
                panel.CssClass = "yellow";
            }
            else
            {
                panel.CssClass = "green";
            }
        }
    }
