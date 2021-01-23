    private void AddCalculatedID(DataTable data)
    {
        var calculatedIDColumn = new DataColumn { DataType = typeof(string), ColumnName = "CalculatedID" };
        data.Columns.Add(calculatedIDColumn);
        data.Columns["CalculatedID"].SetOrdinal(0);
        int jobDetailID = -1;
        int letter = 65;
        foreach (DataRow row in data.Select("","JobDetailID"))
        {
            if((int)row["JobDetailID"] == jobDetailID)
            {
                row["CalculatedID"] = row["JobDetailID"].ToString() + (char)letter;
                letter++;
            }
            else
            {
                letter = 65;
                jobDetailID = (int)row["JobDetailID"];
            }
        }
    }
