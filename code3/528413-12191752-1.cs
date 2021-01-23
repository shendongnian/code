    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            // Place your list View Code here
            <asp:ListView ..........
             ...... </asp:ListView>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnControlID" /> // If button is present inside update panel otherwise use asyn postback trigger
                        // OR
           <asp:AsyncPostBackTrigger ControlID="btnControlID" EventName="Click" /> 
        </Triggers>
    </asp:UpdatePanel>
    // Now Set AssociatedUpdatePanelID="up" in the UpdateProgress
    <asp:UpdateProgress ID="UpdateProgress1" DynamicLayout="true" runat="server"  AssociatedUpdatePanelID="up" >
    <ProgressTemplate>
    <div class="progress">
        <img src="images/ajax-loader-arrows.gif" />&nbsp;please wait...
    </div>
    </ProgressTemplate>
    </asp:UpdateProgress>
