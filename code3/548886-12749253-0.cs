    <asp:GridView ID="userGrid" runat="server" CssClass="AdminGrid" 
                            AllowPaging="True" AutoGenerateColumns="False" PageSize="11">
                            <Columns>                
                                <asp:BoundField DataField="ApplicationId" Visible="False" />
                                <asp:BoundField DataField="UserName" Visible="False" />                                                                   
                                <asp:TemplateField >
                                    <HeaderTemplate>
                                        <asp:Label ID="lblEmail" Text="E-Mail" runat="server" CssClass = "HeaderLabel" meta:resourcekey="lblEmail"></asp:Label>
                                        <asp:ImageButton ID="imgSortEMail" runat="server" ImageUrl="~/Images/normal.gif" OnClick="SortGrid" CommandArgument="EMail" CssClass="SortButton" ToolTip="Click here to Order" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkEMail" runat="server" CssClass="EmailLinkButton" Text='<%# FormatGridTextDisplay(DataBinder.Eval(Container.DataItem, "EMail")) %>' ToolTip='<%# DataBinder.Eval(Container.DataItem, "EMail") %>' NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "EMail","mailto:{0}") %>' ></asp:HyperLink>                                                                                
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="OverFlowStringField" />
                                    <ItemStyle CssClass="OverFlowLeftAligned" />
                                </asp:TemplateField>
                                <asp:TemplateField >
                                    <HeaderTemplate>
                                        <asp:Label ID="lblSalonUser" Text="Salon User" runat="server" CssClass = "HeaderLabel" meta:resourcekey="lblSalonUser"></asp:Label>
                                        <asp:ImageButton ID="imgSortIsSalonUser" runat="server" ImageUrl="~/Images/normal.gif" OnClick="SortGrid" CommandArgument="IsSalonUser" CssClass="SortButton" ToolTip="Click here to Order" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSalonUser" runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "IsSalonUser") %>' onclick="javascript:if (this.checked==true) this.checked=false; else this.checked=true;"/>                      
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="OverFlowStringField" />
                                    <ItemStyle CssClass="CenterAligned" />
                                </asp:TemplateField>
                                <asp:TemplateField >                
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="GridButton" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserName")%> '  OnClick="btnEdit_Click" meta:resourcekey="btnEdit"/>                        
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="OverFlowStringField" />
                                    <ItemStyle CssClass="CenterAligned" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
