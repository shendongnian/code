    //UserControl2.ascx nested inside of UserControl1.ascx
    ...
    <input type="text" runat="server" id="newTextBox" />
    ...
    //UserControl1.ascx.cs nested inside of Page1.aspx
    ...
    public string NewTextBoxId;
    protected void UserControl2PlaceHolder_Load(object sender, EventArgs e) 
    {
        var c = LoadControl("~/Common/Controls/Shared/UserControl2.ascx");
        this.Controls.Add(c);
        NewTextBoxId = ((App.Common.Controls.Shared.UserControl2) c).newTextBox.ClientID;
    }
