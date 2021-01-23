    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Generate a list of 5 integers - this will be the data source for the GridView
            List<int> rows = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                rows.Add(i);
            }
            //Bind the Gridview to the list of integers so we get 5 rows in the UI
            ProductGridview.DataSource = rows;
            ProductGridview.DataBind();
        }
    }
