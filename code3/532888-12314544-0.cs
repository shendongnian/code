    public void CreateFastCSVFile(DataTable table, string strFilePath)
    {
        const int capacity = 5000000;
        const int maxCapacity = 20000000;
        //First we will write the headers.
        StringBuilder csvBuilder = new StringBuilder(capacity);
        csvBuilder.AppendLine(string.Join(",", table.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
        // Create the CSV file and write all from StringBuilder
        using (var sw = new StreamWriter(strFilePath, false))
        {
            foreach (DataRow dr in table.Rows)
            {
                if (csvBuilder.Capacity >= maxCapacity)
                {
                    sw.Write(csvBuilder.ToString());
                    csvBuilder = new StringBuilder(capacity);
                }
                foreach (DataColumn col in table.Columns)
                {
                    csvBuilder.Append(String.Join(",", dr.ItemArray));
                }
            }
            sw.Write(csvBuilder.ToString());
        }
    }
