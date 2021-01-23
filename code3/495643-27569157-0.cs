            DataSet someDataSet = new DataSet();
            SqlDataAdapter adapt = new SqlDataAdapter();
            using(SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand comm1 = new SqlCommand("SELECT * FROM whateverTable", connection);
                SqlCommand comm2g = new SqlCommand("SELECT * FROM whateverTable WHERE condition = @0", connection);
                commProcessing.Parameters.AddWithValue("@0", "value");
                someDataSet.Tables.Add("Table1");
                someDataSet.Tables.Add("Table2");
                adapt.SelectCommand = comm1;
                adapt.Fill(someDataSet.Tables["Table1"]);
                adapt.SelectCommand = comm2;
                adapt.Fill(someDataSet.Tables["Table2"]);
            }
