    public List<string> getFromDataBase() 
    {
        List<string> result = new List<string>();
        using(SqlConnection con = new SqlConnection("connectionString"))
        {
            con.Open();
            DataTable tap = new DataTable();
            new SqlDataAdapter(query, con).Fill(tap);
            result = tap.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("columnName")).ToList();
        }
        return result;
    }
