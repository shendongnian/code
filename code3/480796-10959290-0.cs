    public static List<string> getTablenames(string connString, string QueryString)
    {
        SqlConnection con = new SqlConnection(connString);
        con.Open();
        DataTable dt = con.GetSchema("Tables");
        List<string> getTableName = new List<string>();
        List<string> tablenames = new List<string>();
        foreach (DataRow dr in dt.Rows)
           tablenames.Add(dr[2].ToString());
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string myTable = tablenames[i];
            Boolean checkMyTable = QueryString.Contains(myTable);
            if (checkMyTable == true)
                getTableName.Add(myTable);
        }
        con.Close();
        return getTableName;
    }
