    public IDictionary<string,string> GetExpenseTypes()
    {
        Dictionary<string,string> expArry = new Dictionary<string,string>();
        // Your sql code
        while (reader.Read())
        {
            expArry.Add(reader["TITLE"].ToString(), reader["ID"].ToString());
        }
        // The rest of your code
    }
