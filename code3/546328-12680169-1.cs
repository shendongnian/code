    <asp:GridView runat="server" AutoGenerateColumns="false" ID="rpt">
    <Columns>
    	<ItemTemplate>
    		<%# Eval("Key") %>
    	</ItemTemplate>
    </Columns>
    </asp:Repeater>
    Dictionary<string, string> lst = new Dictionary<string, string>();
    lst.Add("test", String.Empty);
    lst.Add("test1", String.Empty);
    this.rpt.DataSource = lst;
    this.rpt.DataBind();
