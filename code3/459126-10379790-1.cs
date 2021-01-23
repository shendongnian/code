    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadmyHashTable();
            if (myHashTable.Count > 0)
            {
                myDropdownlist.DataSource = myHashTable;
                myDropdownlist.DataTextField = "Value";
                myDropdownlist.DataValueField = "Key";
                myDropdownlist.DataBind();
            }
        }
    }
