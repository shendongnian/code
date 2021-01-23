    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="btnTest" runat="server" Text="Button" />
            <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server"           TargetControlID="btnTest" PopupControlID="Panel"></asp:ModalPopupExtender>
            <asp:Panel ID="Panel" runat="server">
                <h1>Hello World!</h1>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnTest"/>
        </Triggers>
    </asp:UpdatePanel>
