        private static void ReadOrderData(string connectionString)
        {
            string queryString =
                "SELECT OrderID, CustomerID FROM dbo.Orders;";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.Text, queryString))
            {
                // Call Read before accessing data.
                while (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}, {1}",
                    reader[0], reader[1]));
                }
            }
        }
