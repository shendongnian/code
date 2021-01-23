    Label l;
    
    public string FOO()
    {
        return l.Text;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        l = new Label();
        l.Text = "Bar";
    }
