    <asp:Button Text="Search" OnClick="btnSearch_Click" runat="server" ID="btnSearch" />
    // Change <asp:PostBackTrigger ControlID="btnSearch" />
    <asp:AsyncPostBackTrigger ControlID="btnSearch" />
    
    // Code Behind EventHandler
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // Retrieve and Bind Search Data to RadGrid1
     }
    // Check Databind is conditional if required
    protected void Page_Load(object sender, EventArgs e)
    {
        If (!Page.IsPostBack)
        {
            // Bind Data if required
        }    
        
    }
