    <asp:UpdatePanel ID="updPanelNewsletterProgress" runat="server" UpdateMode="Conditional" >
        <Triggers>
            <asp:PostBackTrigger ControlID="Timer1" />
        </Triggers>
        <ContentTemplate>
             <asp:Label ID="lblCounter" runat="server" Text=""></asp:Label><br />
        </ContentTemplate>
    </asp:UpdatePanel> 
    protected void Button1_Click(object sender, EventArgs e)
    {
        Timer1.Enabled = true;
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        int i;
        int.TryParse(ViewState["i"] != null ? ViewState["i"].ToString() : "0", out i);
        if(i == 100)
            Timer1.Enabled = false;
        lblCounter.Text = "Counter " + i.ToString() + " of 100";
        ViewState["i"] = ++i;
    }
