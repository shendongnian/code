       while (dataReader.Read())
       {
            // at every loop, create a new instance of dictionary using the same variable
            Dictionary<string,string> selectResult = new Dictionary<string, string>();
            for (int i = 0; i < dataReader.FieldCount; i++)
            {
                selectResult.Add(dataReader.GetName(i).ToString(), dataReader.GetValue(i).ToString());
            }
            // Adding a different copy of the dictionary in the list
            allResults.Add(selectResult);
        }
