    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        ....
    </asp:UpdatePanel>
    protected void GridViewAllProducts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            new ProductC().DeleteBy_Id(Convert.ToInt32(e.CommandArgument));
    
            GridViewAllProducts.DataSource = new ProductC().GetAllProducts();
            GridViewAllProducts.DataBind();
            UpdatePanel1.Update();
        }
    }
