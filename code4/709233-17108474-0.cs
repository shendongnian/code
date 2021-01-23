    [WebMethod]
    public **string[]** get_currency(string date, string cur_code) {
        **List<string> rtn = new List<string> ();**
        try
        {
            using (SqlConnection conn = new SqlConnection("Data Source=xxx-xxxxx;Initial Catalog=xxx;Persist Security Info=True;User ID=xxx;Password=xxx"))
            {
                string selectSql = "select date,code,banknote_buying,banknote_selling from Currencies where date = '" + date + "' and code ='" + cur_code + "'";
                SqlCommand comm = new SqlCommand(selectSql, conn);
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();
                if (dr.Read()) {
                    rtn.Add( dr["date"].ToString());
                    rtn.Add(dr["code"].ToString());
                     rtn.Add(dr["banknote_buying"].ToString());
                     rtn.Add(dr["banknote_selling"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            return "Fail";
        }
        return rtn.ToArray();
    }
