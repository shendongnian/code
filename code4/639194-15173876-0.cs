    <asp:Button ID="btnMain" Text="Create New Button" runat="server" 
            onclick="btnMain_Click" />
    protected void btnMain_Click(object sender, EventArgs e)
            {
                Button btnNew = new Button();
                btnNew.ID = "btnNew";
                btnNew.Text = "New Button";
                this.Controls.Add(btnNew);
            }
