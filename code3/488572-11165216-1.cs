    <asp:GridView ID="grdResult" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Title">
                    <HeaderTemplate>
                        Title
                    </HeaderTemplate>
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "Title")%></span>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="URL">
                    <HeaderTemplate>
                        URL
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a href="<%#DataBinder.Eval(Container.DataItem, "url")%>" target="_blank">
                            <%#DataBinder.Eval(Container.DataItem, "url")%></a><br />
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
