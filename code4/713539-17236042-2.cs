    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" OnNeedDataSource="RadGrid1_NeedDataSource"
        OnItemDataBound="RadGrid1_ItemDataBound">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn DataField="ID" UniqueName="ID" HeaderText="ID">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get selected Checbox" />
    
