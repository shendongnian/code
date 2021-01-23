    protected void Page_Load(Object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Listbox1.Items.Clear();
            Listbox1.Items.Add(new ListItem("textVar", "valueVar"));
        }
    }
