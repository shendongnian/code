    List<JObject> dataList = new List<JObject>();
    for (int i = 0; i < dataTable.Rows.Count; i++)
    {
        JObject eachRowObj = new JObject();
        for (int j = 0; j < dataTable.Columns.Count; j++)
        {
            string key = Convert.ToString(dataTable.Columns[j]);
            string value = Convert.ToString(dataTable.Rows[i].ItemArray[j]);
            eachRowObj.Add(key, value);
        }
        dataList.Add(dataList);
    }
