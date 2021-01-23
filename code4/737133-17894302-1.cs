     string db =  NAME;
     string myConnectionString = "Data Source=ServerName;" + "Initial Catalog=" + db + "User id=" + ODBC_USR + "Password=" + PWD
     using (SqlConnection connection = new SqlConnection(myConnectionString))
        {
          string mySelectQuery = @"SELECT a,b,c,d,e,f,g,h,i,...
             FROM package p
             JOIN package_download pd on p.package_id = pd.package_id
             join download d on pd.download_id = d.download_id
            WHERE p.package_name = @PackageName
            AND ds.server_address LIKE 'tcp/ip%'
            ORDER by a,b,c,d";
            try
            {
                connection.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(mySelectQuery, connection))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        da.SelectCommand.Parameters.AddWithValue("@PackageName", txtPackage.Text);
                            DataTable dt = new DataTable();
                            da.Fill(dt);         
                            if (dt.Rows.Count>0) // Make sure there is something in your DataTable
                             {
                               String aVal = dt[0]["a"].ToString();
                               String bVal = dt[0]["b"].ToString();
                               // You'll be the one to fill up
                             }                                                          
                    }
                }
            }
            catch (Exception ex)
            {
              MessageBox.Show(ex.Message);
            }
        }
