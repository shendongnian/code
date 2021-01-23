        private static void AddCalculatedID(DataTable data)
        {
            data.BeginLoadData();
            try
            {
                var calculatedIDColumn = new DataColumn { DataType = typeof(string), ColumnName = "CalculatedID" };
                data.Columns.Add(calculatedIDColumn);
                data.Columns["CalculatedID"].SetOrdinal(0);
                var jobDetails = new Dictionary<string, int>(data.Rows.Count);
                foreach (DataRow row in data.Rows)
                {
                    var jobDetailID = row["JobDetailID"].ToString();
                    int lastSuffix;
                    if (jobDetails.TryGetValue(jobDetailID, out lastSuffix))
                    {
                        lastSuffix++;
                    }
                    else
                    {
                        // ASCII value for A
                        lastSuffix = 65;
                    }
                    row["CalculatedID"] = jobDetailID + (char)lastSuffix;
                    jobDetails[jobDetailID] = lastSuffix;
                }
            }
            finally
            {
                data.EndLoadData();
            }
        }
