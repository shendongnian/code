    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        </asp:ScriptManagerProxy>
        <div>
            <asp:UpdatePanel ID="UpdTabContainer" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <asp:TabContainer ID="TabContainer1" runat="server" AutoPostBack="true">
                        <asp:TabPanel ID="TabDeliveryControl" runat="server" HeaderText="Delivery-Control">
                            <HeaderTemplate>
                                <asp:Panel ID="PnlTabDeliveryControl" runat="server" ToolTip="Delivery-Control">
                                    Delivery-Control
                                </asp:Panel>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <SVCS:SVCSDeliveryControl id="SVCSDeliveryControl" runat="server" Visible="false" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="TabContainer1" EventName="ActiveTabChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="TabRepair" runat="server" HeaderText="Repair-Area" >
                            <HeaderTemplate>
                                <asp:Panel ID="PnlTabRepair" runat="server" ToolTip="Repair-Area">
                                    Repair-Area
                                </asp:Panel>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <SVCS:SVCSRepair id="SVCSRepair" runat="server" Visible="false" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="TabContainer1" EventName="ActiveTabChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="TabShipping" runat="server" HeaderText="Shipping" Visible="false">
                            <HeaderTemplate>
                                <asp:Panel ID="PnlTabShipping" runat="server" ToolTip="Shipping">
                                    Shipping
                                </asp:Panel>
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <SVCS:SVCSShipping id="SVCSShipping" runat="server" Visible="false" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="TabContainer1" EventName="ActiveTabChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </asp:TabPanel>
                    </asp:TabContainer>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </asp:Content>
