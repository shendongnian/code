    <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server">
            <Columns>
                <asp:BoundField DataField="column1" HeaderText="Column1" SortExpression="" />
              <asp:BoundField DataField="column2" HeaderText="Column2" SortExpression="" />
                <asp:TemplateField SortExpression="points">
                <HeaderTemplate>HELLO</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("hello") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
