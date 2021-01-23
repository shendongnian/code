    string connectionString = WebConfigurationManager.ConnectionStrings["Gen_Lic"].ConnectionString; //<-- error
     string selectSQL = "SELECT * FROM Gen_Lic";
     SqlConnection con = new SqlConnection(connectionString);
     con.Open();// Need to Open Connection before to Create SQL Comamnd
     SqlCommand cmd = new SqlCommand(selectSQL, con);
     SqlDataAdapter adapter = new SqlDataAdapter(cmd);
     DataSet ds = new DataSet();
    
     adapter.Fill(ds, "Gen_Lic");
    
     Gen_Lic_Grid.DataSource = ds;
     Gen_Lic_Grid.DataBind();
