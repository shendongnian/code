          <asp:LinkButton ID="topNav-home" runat="server" OnClick="clickCounter"><img src="img.png" /></asp:LinkButton>
    
    protected void clickCounter(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)sender;
        string id = lbtn.ID;
    }
