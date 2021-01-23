    static IEnumerable<string> Load(string tableName, string columnName)
    {
        List<string> result = new List<string>();
        try
        {
            using (var cn = new SqlConnection(@"Data Source=Nick-PC\SQLEXPRESS;Initial Catalog=AutoDB;Integrated Security=True"))
            {
                cn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM " + tableName, cn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(reader[columnName].ToString());
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        return result;
    }
