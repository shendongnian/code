     <asp:GridView ID="GrdDynamic" runat="server" OnRowDataBound="GridView_RowDataBound">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:PlaceHolder runat='server' ID="PlaceHolder1"></asp:PlaceHolder>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    public void GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        //find placeholder control
        PlaceHolder placeHolder = e.Row.FindControl("PlaceHolder1") as PlaceHolder;
        
        TextBox TextBox1 = new TextBox();
        placeHolder.Controls.Add(TextBox1);      
    }
