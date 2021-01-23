    private void initialData()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["defaultconnection"].ConnectionString;
        string query = "select * from Ressources";
        
        if (Session["datatableinsession"] == null)
        {        
            OriginalDataTable = new DataTable();
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connectionString))
            {
                dataAdapter.Fill(OriginalDataTable);
            }
        }
        else
        {
            OriginalDataTable = Session["datatableinsession"] as DataTable;
        }
        
    }
