    private void AddCalculatedID(DataTable data)
    {
        var calculatedIDColumn = new DataColumn { DataType = typeof(string), ColumnName = "CalculatedID" };
        data.Columns.Add(calculatedIDColumn);
        data.Columns["CalculatedID"].SetOrdinal(0);
        Dictionary<string, string> UsedKeyIndex = new Dictionary<string, string>();
    
        foreach (DataRow row in data.Rows)
        {
            string jobDetailID = row["JobDetailID"].ToString();
            string calculatedID;
    
            if (UsedKeyIndex.ContainsKey(jobDetailID))
            {
              calculatedID = jobDetailID + 'A';
              UsedKeyIndex.Add(jobDetailID, 'A');
            }
            else
            {
               char nextKey = UsedKeyIndex[jobDetailID].Value+1;
               calculatedID = jobDetailID + nextKey;
               UsedKeyIndex[jobDetailID] = nextKey;
            }
            
            row["CalculatedID"] = calculatedID;
        }
    }
