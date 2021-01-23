    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostback)
        {
            string sqlQuery = "select * from registrants";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["FFL-New DataConnectionString"].ConnectionString))
            {
                using (SqlCommand searchCommand = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                          dt.Load(reader);
                    }
                }
            }
            RegistrantsView.DataSource = dt;
            RegistrantsView.DataBind();
        }
    }
