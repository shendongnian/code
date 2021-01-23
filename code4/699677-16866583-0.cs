    <asp:TextBox ID="tbx_rms" onchanged="textboxcalc" AutoPostback="true" runat="server"></asp:TextBox>
    <asp:TextBox ID="tbx_volt" onchanged="textboxcalc" AutoPostback="true" runat="server"></asp:TextBox>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="tbx_rms" />
            <asp:AsyncPostBackTrigger ControlID="tbx_volt" />
            <asp:AsyncPostBackTrigger ControlID="tbx_eff" />
        </Triggers>
        <ContentTemplate>
          <asp:TextBox ID="tbx_anw1" Enabled="false" runat="server"></asp:TextBox>
          <asp:TextBox ID="tbx_anw2" Enabled="false" runat="server"></asp:TextBox>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:TextBox ID="tbx_eff" onchanged="textboxcalc" AutoPostback="true" runat="server"></asp:TextBox>    
    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="tbx_rms" />
            <asp:AsyncPostBackTrigger ControlID="tbx_volt" />
            <asp:AsyncPostBackTrigger ControlID="tbx_eff" />
        </Triggers>
        <ContentTemplate>
            <asp:TextBox ID="tbx_anw3" Enabled="false" runat="server"></asp:TextBox>
        </ContentTemplate>
    </asp:UpdatePanel>
