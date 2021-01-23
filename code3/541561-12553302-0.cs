    string conn = ConfigurationManager.ConnectionStrings["BazaConnectionString"].ConnectionString;
    using (SqlConnection connect = new SqlConnection(conn))
    using (SqlCommand cmd = new SqlCommand("SELECT * FROM  Seminar", connect))
    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
    {
       try
       {
          DataTable tablica = new DataTable();
          sqlAdapter.Fill(tablica);
          GridView1.DataSource = tablica;
          GridView1.DataBind();
       }
       catch(Exception exc)
       {
           string msg = exc.GetType().FullName + ": " + exc.Message;
       }
    }
