    protected void Page_Load(object sender, EventArgs e)
    {
    if(!Page.IsPostBack) 
    {
        //Bind it once on first time page load
        MyListbox.DatSource = SqlDataSource1();
        MyListbox.DataBind();
    }
    }
