            var sConnection = "Server=(localdb);Initial Catalog=Database1;Integrated Security=true;";
            using (var sqlConn = new SqlConnection(sConnection))
            {
                sqlConn.Open();
                using (var cmd = sqlConn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Table2 ORDER BY [Customer Name]";
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            aMember = new member(reader["Name2"].ToString());
                            this.listBox1.Items.Add(aMember); 
                        }
                    }
                }
            }
