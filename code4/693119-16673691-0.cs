    <asp:Button ID="Button1" runat="server" Text="Button" 
      OnClick="Button1_Click"/>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
    private List<int> ControlIds
    {
        get { return (List<int>) ViewState["ControlIds"] ?? new List<int>(); }
        set { ViewState["ControlIds"] = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            var ids = ControlIds;
            foreach (var id in ids)
            {
                var txt = new TextBox {ID = "txt_" + id};
                form1.Controls.Add(txt);
            }
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        var random = new Random();
        int randomNumber = random.Next(0, 100);
    
        var ids = ControlIds;
        if (ids.Contains(randomNumber))
        {
            // Randam number already exists
            return;
        }
    
        ids.Add(randomNumber);
        ControlIds = ids;
    
        var btnSomeButton = sender as Button;
        btnSomeButton.Text = "I was clicked!" + randomNumber;
    
        var txt = new TextBox
            {
                ID = "txt_" + randomNumber,
                Text = randomNumber.ToString() // Just for testing
            };
        form1.Controls.Add(txt);
    }
