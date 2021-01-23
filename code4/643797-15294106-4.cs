    public DataView GetCityCount()
    {
       using (SqlConnection con = new SqlConnection("Put Your Connection String"))// **must Put Your Connection String**
       {
          string sql1 = string.Format(@"SELECT COUNT(*) as TotalCityCount From TableName");
          SqlDataAdapter da1 = new SqlDataAdapter(sql1, con);
          DataSet ds1 = new DataSet();
          con.Open();
          da1.Fill(ds1);
          return ds1.Tables[0].DefaultView;
       }
    } 
    
    Public Void getTotal()
    {
       DataView dv=GetCityCount();
       int totalcity=Convert.ToInt32(dv.Tables[0]["TotalCityCount"])//You get the total Count value in this totalcity variable
    }
