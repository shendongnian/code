    <asp:UpdatePanel ID="updatePanelPromptB" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:Label ID="labelPlayback" runat="server"></asp:Label>
    </ContentTemplate> 
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="timerPromptB" EventName="Tick" />
    </Triggers>
    </asp:UpdatePanel>
    <asp:Timer runat="server" ID="timerPromptB" OnTick="timerPromptB_Tick" Enabled="false" Interval="4000" />
    private void promptBottom(string text)
    {
        labelPlayback.Text = text;
        updatePanelPromptB.Update();
        timerPromptB.Enabled = true;
    }
    protected void timerPromptB_Tick(object sender, EventArgs e)
    {
        labelPlayback.Text = "OK";
        timerPromptB.Enabled = false;
    }
