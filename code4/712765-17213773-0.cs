      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:ListView ID="SearchListView" runat="server">
                                            <LayoutTemplate>
                                                 </LayoutTemplate> 
                                            </asp:ListView> 
                                        </ContentTemplate> 
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="SearchListView" EventName="SelectedIndexChanged" />
                        </Triggers>
            </asp:UpdatePanel> 
        
