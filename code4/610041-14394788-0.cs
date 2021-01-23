    <asp:ObjectDataSource ID="objGetUserName" runat="server" SelectMethod="getUserNameByEmail"
        TypeName="PageClassName" OnSelecting="objGetUserName_Selecting">
    internal static DataTable getUserNameByEmail(string email)
    {
        var proxy = new SecureService();
        proxy.Credentials = new NetworkCredentials("user-name", "password");
        return proxy.getUserNameByEmail(email);
    }
