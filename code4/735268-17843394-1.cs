    <asp:DropDownList runat="server" ID="DropDownList1" AutoPostBack="True" 
        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" />
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string path = @"C:\DevelopmentArchive\TelerikDemo\TelerikDemo";
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles("*.aspx");
    
            foreach (var file in files.OrderByDescending(f => f.CreationTime))
                DropDownList1.Items.Add(new ListItem(file.Name.Replace(".aspx", ""), file.Name));
                    
            DropDownList1.Items.Insert(0, new ListItem("Select Edition", ""));
        }
    }
    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect(DropDownList1.SelectedItem.Value);
    }
