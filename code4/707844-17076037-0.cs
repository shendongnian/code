    using (var conn = new SqlConnection("you connection string here"))
            using (var command = new SqlCommand("[dbo].[testing] ", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                foreach (DataRow x in dt.Rows) {
                    Console.WriteLine("First column value : "   + x[0]);
                }
            }
