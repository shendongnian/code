    [WebMethod]
    public static List<string> GetAutoCompleteData(string CategoryName)
    {
        List<string> result = new List<string>();
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"|DataDirectory|\\ImageDB2.mdb\";Persist Security Info=True");
        string query = "select TagName from TAGS where TagName LIKE '%" + CategoryName + "%'";
        OleDbCommand cmd = new OleDbCommand(query, con);
        con.Open();
        //cmd.Parameters.Add("@ptext", System.Data.SqlDbType.NVarChar).Value = CategoryName;
        OleDbDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            result.Add(dr["TagName"].ToString());
        }
        return result;
    }
