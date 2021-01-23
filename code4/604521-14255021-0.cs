    Place the commandName in aspx page 
    
     <asp:Button  ID="btnDelete" Text="Delete" runat="server" CssClass="CoolButtons" CommandName="DeleteData"/>
    
    subscribe the  rowCommand event for the grid  and you can try like this, 
    
    protected void grdBillingdata_RowCommand(object sender, GridViewCommandEventArgs e)
    {
            if (e.CommandName == "DeleteData")
            {
                GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                HiddenField hdnDataId = (HiddenField)row.FindControl("hdnDataId");
             }
    }
