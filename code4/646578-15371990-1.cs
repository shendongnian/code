    <asp:TextBox runat="server" ID="txtFName" /><br />
    <asp:Button runat="server" ID="btnEnter" Text="Submit" OnClick="btnEnter_Click" /><br />
    <asp:Label runat="server" ID="lblFName" /><br />
    <asp:Label runat="server" ID="lblFName1" /><br />
    <asp:Label runat="server" ID="lblFName2" /><br />
    <asp:Label runat="server" ID="lblFName3" /><br />
    <asp:Label runat="server" ID="lblFName4" /><br />
    
    [Serializable]
    public class Recipient
    {
        public string name { get; set; }
    }
    
    public List<Recipient> recipientList
    {
        get
        {
            if (ViewState["recipientList"] != null)
                return (List<Recipient>)ViewState["recipientList"];
            return new List<Recipient>();
        }
        set { ViewState["recipientList"] = value; }
    }
    
    protected void btnEnter_Click(object sender, EventArgs e)
    {
        List<Recipient> recipient = recipientList;
        recipient.Add(new Recipient{ name = txtFName.Text.Trim()});
        recipientList = recipient;
    
        int count = recipient.Count;
    
        if (count == 1)
            lblFName.Text = recipientList[0].name;
    
        if (count > 1)
            lblFName1.Text = recipientList[1].name;
    
        if (count > 2)
            lblFName2.Text = recipientList[2].name;
    
        if (count > 3)
            lblFName3.Text = recipientList[3].name;
    
        if (count > 4)
            lblFName4.Text = recipientList[4].name;
    }
