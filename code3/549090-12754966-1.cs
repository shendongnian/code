    protected void Page_Load(object sender, EventArgs e)
    {
       if(!Page.IsPostBack)
       {
           MyList.DataSource = getDataFromDB();
           MyList.DataBind();
       }
    }
    //this function can return IEnumerable e.g. DataTable of Person, List<Person>, SqlDataReader etc
    private DataTable getDataFromDB()
    {
       //select data from database
       //return data;
    }
