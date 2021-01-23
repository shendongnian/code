     <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="العربية" SortExpression="العربية">
                    <ItemTemplate>
                        <asp:Label ID="arabic" runat="server" Text='<%# Eval("العربية")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <Columns>
                <asp:TemplateField HeaderText="English" SortExpression="English">
                    <ItemTemplate>
                        <asp:Label ID="english" runat="server" Text='<%# Eval("English") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="deleteButton" runat="server" Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="open" runat="server" Text="Open" NavigateUrl="~/Default.aspx"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT [English], [العربية] FROM [Test]"></asp:SqlDataSource>
        <br />
        <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export to PDF" />
