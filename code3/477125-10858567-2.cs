    public List<string> GetCustomerInfo(string custName)
    {
        List<string> result = new List<string>();
        string sql = "Select Name from Customers Where Name like @partName";
        using(SqlConnection con = GetConnection())
        using(SqlCommand cmd = new SqlCommand(sql, con))
        {
             con.Open();
             cmd.Parameters.AddWithValue("@partName", custName + "%"); 
             using(SqlDataReader r = cmd.ExecuteReader())
             {
                  while(r.Read()) 
                  {
                      if(!r.IsDbNull(0)) 
                          result.Add(r.GetString(0)); 
                  }
             }
        } 
        return result; 
    } 
