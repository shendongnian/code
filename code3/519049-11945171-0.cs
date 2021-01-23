    <asp:TemplateField HeaderText="Edit" AccessibleHeaderText="Edit">
        <ItemTemplate>
            <asp:HyperLink ID="EditUsername" runat="server" NavigateUrl='<%# Link.ToMemberAdmin(Eval("Username").ToString())%>'
                Text="Edit" />
            <asp:Button ID="DeleteButton" runat="server" Text="Delete Entry" OnClick="DeleteButton_Click"
			    CommandArgument='<%#Eval("Username")+"^"+Eval("Email") %>'/>
        </ItemTemplate>
    </asp:TemplateField>
	protected void DeleteButton_Click(object sender, EventArgs e)
	{
		var btn = sender as Button;
		var args = btn.CommandArgument.Split('^');
		string username = args[0];
		string email = args[1];
		AdminAccess.DeleteMemberApplication(username, email);
	}
