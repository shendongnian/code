        public void TestCommandBuilder()
        {
            var pubs = ConfigurationManager.ConnectionStrings["PubsConnectionString"];
            using (var pubsDataSet = new DataSet("Pubs"))
            using (var connection = new SqlConnection(pubs.ConnectionString))
            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Publishers";
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(pubsDataSet, "publishers");
                    foreach (DataRow row in pubsDataSet.Tables["publishers"].Rows)
                    {
                        row["pub_name"] = "Updated " + DateTime.Now.Minute + DateTime.Now.Second;
                    }
                    // The variable builder is not used
                    using (var builder = new SqlCommandBuilder(da))
                    {
                        da.UpdateBatchSize = 3;
                        da.RowUpdated += DaRowUpdated;
                        da.Update(pubsDataSet, "publishers");
                    }
                }
            }
        }
        private void DaRowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            Console.WriteLine("Rows: " + e.RecordsAffected);
        }
