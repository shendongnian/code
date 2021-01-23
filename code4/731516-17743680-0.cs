    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" OnNeedDataSource="RadGrid1_NeedDataSource"
        OnUpdateCommand="RadGrid1_UpdateCommand" AllowFilteringByColumn="true" AllowPaging="true"
        AllowMultiRowEdit="true">
        <MasterTableView DataKeyNames="ID" EditMode="InPlace">
            <Columns>
                <telerik:GridBoundColumn DataField="ID" UniqueName="ID" HeaderText="ID">
                </telerik:GridBoundColumn>
                <telerik:GridEditCommandColumn>
                </telerik:GridEditCommandColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="update All edit row" />
