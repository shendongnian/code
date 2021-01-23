    <div id="Parent" runat="server">
    </div>
    <asp:Button ID="btnTest" runat="server" Text="Get text" OnClick="btnTest_Click" />
    protected void Page_Init(object sender, EventArgs e)
    {
        TextBox textInput = new TextBox();
        textInput.ID = "text1";
        textInput.Text = "Test";
        Parent.Controls.Add(textInput);
    }
    protected void btnTest_Click(object sender, EventArgs e)
    {
        Response.Write((Parent.FindControl("text1") as TextBox).Text);
    }
