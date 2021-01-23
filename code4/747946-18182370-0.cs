    public DataSet Query(string query, Dictionary<string, string> parameters)
    {
        DataSet result = new DataSet();
        using (SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection))
        {
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.SelectCommand.CommandText = query;
            foreach (KeyValuePair<string, string> pair in parameters)
            {
                //THIS BIT IS IMPORTANT, NOTE THE STRING FORMAT!
                adapter.SelectCommand.Parameters.Add(new SqlParameter(string.Format("@{0}", pair.Key), pair.Value));
            }
            adapter.Fill(result);
        }
        return result;
    }
