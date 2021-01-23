          <asp:TemplateField HeaderText="Edit>
     <ItemTemplate>
            <asp:LinkButton Id="lnkEdit" runat="server" CommandName="Edit" Text="Edit"/>
    </ItemTemplate>
    <EditItemTemplate>
                <asp:LinkButton Id="lnkEdit" runat="server" CommandName="Update" Text="Update"/>
                <asp:LinkButton Id="LinkButton1" runat="server" CommandName="Cancel" Text="Cancel"/>
                </EditItemTemplate>
            </asp:TemplateField>
    
    OnRowEditEvent() set the gridview edit index to e.newrowindex and bind it again like this.
    
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataBind();
        
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
    //Write cODE TO UPDATE YOUR DATABESE THEN WRITE BELOW CODE IN LAST
    GridView1.EditIndex = -1;
            GridView1.DataBind();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }
