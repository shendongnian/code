    string connectionString = YOUR_NAME_SPACE.Properties.Settings.Default.CONNECTION_STRING;
                SqlConnection con = new SqlConnection(connectionString);
                DataTable DT = new DataTable();
                con.Open();
    
                SqlDataAdapter DA = new SqlDataAdapter(YOUR_QUERYQUERY, connectionString);
                DA.Fill(DT);
                con.Close();
                return DT;
