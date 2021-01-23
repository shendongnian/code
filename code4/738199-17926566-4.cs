    <asp:GridView ID="GridView1" runat="server" ...>
        <Columns>
            <asp:TemplateField HeaderText="Approved">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" .../>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Denied">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox2" ... />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
