                //add your connection string between ""
                string connectionString = "";
                using (var conn = new SqlConnection(connectionString))
                using (DbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO pdf (Id, Name) VALUES (5, 'kk')";
                   
                    conn.Open();
                    conn.ExecuteNonQuery();
                    
                    conn.Close();
                 }
