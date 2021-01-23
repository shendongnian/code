       string Sql = "select company_name from JO.dbo.Comp";
       SqlConnection conn = new SqlConnection(connString);
       conn.Open();
       SqlCommand cmd = new SqlCommand(Sql, conn);
       SqlDataReader DR = cmd.ExecuteReader();
                while (DR.Read())
                {
                    combobox1.Items.Add(DR[0]);
                    
                }
