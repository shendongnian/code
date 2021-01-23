    <asp:Button runat="server" ID="Button1" OnClick="Button1_Click" 
     Text="Create TextBoxes" />
    <asp:Button runat="server" ID="Button2" OnClick="Button2_Click"      
      Text="Save TextBoxes to Database" />
    <asp:PlaceHolder runat="server" ID="PlaceHolder1"></asp:PlaceHolder>
    
    public int Counter
    {
        get { return Convert.ToInt32(ViewState["Counter"] ?? "0"); }
        set { ViewState["Counter"] = value; }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        // Need to reload those textboxes on post back.
        // Otherwise, they will become null.
        int total = Counter;
        for (int i = 0; i < total; i++)
        {
            var textBox = new TextBox
            {
                ID = "TextBox" + i,
                Text = "TextBox" + i
            };
            PlaceHolder1.Controls.Add(textBox);
        }
    }
    
    private void CreateTextBox(int total) 
    {
        for (int i = 0; i < total; i++)
        {
            var textBox = new TextBox
            {
                ID = "TextBox" + i,
                Text = "TextBox" + i
            };
            PlaceHolder1.Controls.Add(textBox);
        }
        Counter = total;
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        CreateTextBox(4);
    }
    
    protected void Button2_Click(object sender, EventArgs e)
    {
        int total = Counter;
        for (int i = 0; i < total; i++)
        {
            var textbox = PlaceHolder1.FindControl("TextBox" + i) as TextBox;
            var text = textbox.Text;
            // Do something with text
        }
    }
