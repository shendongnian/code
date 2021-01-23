    public List<MyClass> GetData()
    {
        DataTable table = new DataTable("Table");
        using (SqlConnection connection = new SqlConnection("Connection string"))
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "query string";
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            foreach(DataRow row in table)
            {
                MyClass instance = new MyClass();
                instance.ID = row["ID"];
                similarly for rest of the properties
    
                list.Add(instance);
            }
    
        }
        ...
        return [List of MyClass];
    }
