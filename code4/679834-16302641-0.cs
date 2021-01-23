    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" />
            <asp:BoundField HeaderText="Name" DataField="Name" />
            <asp:BoundField HeaderText="Actual Value" DataField="Total" />
            <asp:BoundField HeaderText="Using Bound Field" DataField="Total" 
                DataFormatString="{0:0.000%}" />
            <asp:TemplateField HeaderText="Using Eval">
                <ItemTemplate>
                    <asp:Label runat="server" ID="Label1" 
                        Text='<%# string.Format("{0:0.000%}", Eval("Total")) %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </asp:Content>
    
    private class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Total { get; set; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        var items = new List<Item>
            {
                new Item {Id = 1, Name = "One", Total = 1.0M},
                new Item {Id = 2, Name = "Two", Total = 0.2M},
                new Item {Id = 3, Name = "Three", Total = 0.03M},
                new Item {Id = 4, Name = "Four", Total = 0.004M},
                new Item {Id = 5, Name = "Five", Total = 0.0005M},
                new Item {Id = 6, Name = "Six", Total = 0.00006M},
            };
    
        GridView1.DataSource = items;
        GridView1.DataBind();
    }
