      public void DoWork(string connectionstring)
        {
            DataTable dt = new DataTable("MyData");
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                string commandtext = "SELECT * FROM MyTable";
                using(var adapter = new SqlDataAdapter(commandtext, connection))
                {
                    adapter.Fill(dt);
                }
                
            }
            Console.WriteLine(dt.Rows.Count);
        }
