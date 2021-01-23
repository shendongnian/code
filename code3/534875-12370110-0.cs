    <asp:TemplateField HeaderText="Edit">
        <ItemTemplate>
            <asp:Button ID="EditImageButton" runat="server" Text="Edit" CommandName="Edit"' />
        </ItemTemplate>
        <EditItemTemplate>
            <asp:Button ID="UpdateButton" runat="server" ToolTip="Save" CommandName="Update"/>
        </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField>
        <ItemTemplate>
            <% #Eval("Status")%>
        </ItemTemplate>
        <EditTemplate>
            <asp:DropdownList ID="List" runat="server" />
        <EdiTemplate>
    </asp:TemplateField>
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataSource = Session["domainData"];
            GridView1.DataBind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int index = GridView1.EditIndex;
        int key = Convert.ToInt32(GridView.DataKeys[index].Value);
        GridViewRow row = GridView1.Rows[index];
        DropdownList = row.FindControl("List") as DropDownList;
        // Save changes to database
        // GridView1.EditIndex = -1;
        // Rebind grid data
    }
