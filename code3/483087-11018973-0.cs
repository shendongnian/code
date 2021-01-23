    public void Insert_Met(int? counts, char gender)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters.Add("@Counts", counts ?? DBNull.Value);
        parameters.Add("@Gender", gender);
        // run a stored procedure ExecuteNonQuery
    }
