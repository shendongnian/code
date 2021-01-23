    // probably should be renamed, btw
    private string isDBNull(SqlDataReader r, int columnOrder)
    {
        if (!r.IsDBNull(columnOrder))
        {
            return r[columnOrder].ToString();
        }
        else return "";
    }
