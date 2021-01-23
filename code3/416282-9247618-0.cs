    <asp:GridView ID="grd" runat="server" AutoGenerateColumns="false"
                OnRowDataBound="grd_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="btn1" runat="server" Text="click Me" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink btn1 = (HyperLink)e.Row.FindControl("btn1");
            btn1.NavigateUrl = "mailto:abc@yahoo.com";
        }
    }
