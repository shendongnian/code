    protected void Page_Load(object sender, EventArgs e)
    {
        cnn.ConnectionString= ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        if(!IsPostBack)
        {
            // This will only happen when the page is first loaded, as the first time is not considered a post back, but all others are
            dr1 = TableUtoP(); 
            dtWordsList.Load(dr1);
        }
    }
