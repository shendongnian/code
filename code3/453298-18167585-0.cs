    private static void addEmptyElementsToXML(DataSet dataSet)
    {
        foreach (DataTable dataTable in dataSet.Tables)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                for (int j = 0; j < dataRow.ItemArray.Length; j++)
                {
                    if (dataRow.ItemArray[j] == DBNull.Value)
                        dataRow.SetField(j, string.Empty);
                }
            }
        }
    }
