    <asp:UpdatePanel ID="UpDetail" runat="server" RenderMode="Inline" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label ID="AAAA" runat="server"> LOL </asp:Label>
            <asp:Label ID="Label1" runat="server"> <%= DateTime.Now.ToString() %> </asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GvGestionnaires" EventName="SelectionChanged" />
        </Triggers>
    </asp:UpdatePanel>    
