    <asp:PlaceHolder runat="server" ID="PlaceHolder1" />
    <asp:Label runat="server" ID="Label1"/>
    
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadControls();
    }
    
    private void LoadControls()
    {
        var button = new Button {ID = "BtnTag", Text = "Tag generieren"};
        button.Click += button_Click;
        PlaceHolder1.Controls.Add(button);
    }
    
    private void button_Click(object sender, EventArgs e)
    {
        Label1.Text = "BtnTag button is clicked";
    }
