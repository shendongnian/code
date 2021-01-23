    <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
        </asp:Timer> // For one minute
    <asp:UpdatePanel ID="UpdatePanel1"
        runat="server">
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick">
            </asp:AsyncPostBackTrigger>
        </Triggers>
    </asp:UpdatePanel>
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        // Label1.Text = DateTime.Now.Second.ToString();
    }
