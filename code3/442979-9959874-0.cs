    <asp:GridView runat="server" ID="ProductGridview" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Product Name">
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="ProductNameTextBox" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Lot #">
                <ItemTemplate>
                    <asp:DropDownList runat="server" ID="LotNumberDropDownList">
                        <asp:ListItem Text="1" />
                        <asp:ListItem Text="2" />
                        <asp:ListItem Text="3" />
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Image">
                <ItemTemplate>
                    <asp:FileUpload runat="server" ID="ImageFileUpload" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Active">
                <ItemTemplate>
                    <asp:CheckBox Text="Active" runat="server" ID="ActiveCheckBox" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button Text="Save Products" runat="server" ID="SaveProductsButton" OnClick="SaveProductsButton_Click" />
