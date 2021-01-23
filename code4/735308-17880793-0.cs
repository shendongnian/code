    <asp:GridView ID="gvUserInfo" runat="server" 
        onrowdatabound="gvUserInfo_RowDataBound1">
     <Columns>
    <asp:TemplateField>
    <ItemTemplate>
    <asp:LinkButton ID="lnkButton" runat="server" Text="Link"></asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    </asp:GridView>
    protected void gvUserInfo_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = e.Row.FindControl("lnkButton") as LinkButton;
                lnk.ForeColor = System.Drawing.Color.Red;
            }
        }
