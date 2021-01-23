    <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="True" 
        OnDataBound="GridView1_DataBound" AllowPaging="True" PageSize="2">
        <PagerTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="pager" />
        </PagerTemplate>
    </asp:GridView>
    <style type="text/css">
        .pager a { padding: 3px 10px; }
    </style>
    
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        SetPaging();
    }
    
    private void SetPaging()
    {
        GridViewRow row = GridView1.BottomPagerRow;
    
        for (int i = 1; i < GridView1.PageCount; i++)
        {
            var linkButton = new LinkButton
                {
                    CommandName = "Page", 
                    CommandArgument = i.ToString(),
                    Text = "Batch" + i
                };
            var panel = row.FindControl("Panel1") as Panel;
            panel.Controls.Add(linkButton);
        }
    }
