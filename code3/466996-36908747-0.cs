    public List<string> getFromDataBase() 
    {
        List<string> result = new List<string>();
        SqlConnection con = new SqlConnection("connectionString");
        try {
            con.Open();
            DataTable tap = new DataTable();
            new SqlDataAdapter(query, con).Fill(tap);
            result = tap.Rows.OfType<DataRow>().Select(dr => dr.Field<string>("columnName")).ToList();
        }
        catch (Exception) {
                //Exception   
        }
        finally {
            if (con != null)
                con.Close();
        }
        return result;
    }
