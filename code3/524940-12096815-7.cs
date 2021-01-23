    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetFocus(parttxtbox);
            table = new DataTable();
            MakeDataTable();
        }
        else
        if(Session["table"] != null)
            table = (DataTable)ViewState["table"];
    }
    protected void MakeDataTable()
    {
        table.Columns.Add("Part", typeof(string));
        table.Columns.Add("Quantity", typeof(Int32));
        table.Columns.Add("Ship-To", typeof(string));
        table.Columns.Add("Requested Date", typeof(string));
        table.Columns.Add("Shipping Method", typeof(string));
    
        //Persist the table in the Session object.
        Session["table"] = table; //This adds table without any record in it. 
    
        //Bind data to the GridView control.
        BindData();
    }
