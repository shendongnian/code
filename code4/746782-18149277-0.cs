    private IEnumerable<String> GetCategoryNames(String argConnectionString)
    {
       using(SqlConnection con = new SqlConnection(argConnnectionString))
       {
           con.Open()
           using(SqlCommand com = new SqlCommand("Select CatName From Category Where cid > 0", con))
           {
               using(SqlDataReader reader = com.ExecuteReader())
               {
                  while (reader.Read())
                  {
                      yield reader[0].ToString();
                  }
               }
           }
       }
    }
 
