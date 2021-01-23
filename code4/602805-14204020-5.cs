        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Checkbox Column">
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBoxID" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Visible Column">
                    <ItemTemplate>
                        <asp:Label ID="lblVisibleColumn"  runat="server" Text='<%# Eval("VisibleColumn")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="Hidden Column" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblHiddenColumn"  runat="server" Text='<%# Eval("HiddenColumn")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
            </Columns>
        </asp:GridView>
    
        <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
