    <asp:CheckBox ID="cbIsCollected" runat="server"  AutoPostBack="Trye" 
    OnCheckedChanged="cbIsCollected_CheckedChanged" CssClass="isCollectedCheckBox" />
    Protected Sub cbIsCollected_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        dim cbSender as checkbox
        cbSender = ctype(sender, checkbox)
    
    end Sub
