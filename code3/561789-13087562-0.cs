        private Dictionary<string, List<DateTime>> runDates = new Dictionary<string, List<DateTime>>();
        private void LoadData()
        {
            DataTable table = new DataTable();
            table.Columns.Add("TempName", typeof(string));
            using (var connection = new SqlConnection("YourConnectionString"))
            using (var command = new SqlCommand("SELECT DISTINCT TempName, RunDate FROM History_Table;", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tempName = reader.GetString(0);
                        if (!runDates.ContainsKey(tempName))
                        {
                            DataRow row = table.NewRow();
                            row[0] = tempName;
                            table.Rows.Add(row);
                            runDates.Add(tempName, new List<DateTime>());
                        }
                        runDates[tempName].Add(reader.GetDateTime(1));
                    }
                }
                GridView1.DataSource = table;
                GridView1.DataBind();
            }
        }
