    public List<string> GetCustomerInfo(string custName)
    {
        int count = 10; 
        string sql = "Select * from Customers Where Name like @partName";
        using(SqlConnection con = GetConnection())
        {
             SqlDataAdapter da = new SqlDataAdapter(sql, con));
             da.SelectCommand.Parameters.AddWithValue("@partName", custName + "%"); 
             DataTable dt = new DataTable(); 
             da.Fill(dt); 
             List<string> result = new List<string>();
             foreach (DataRow dr in dt.Rows) 
                  result.Add(dr["Name"].ToString()); 
        } 
        return result; 
    } 
