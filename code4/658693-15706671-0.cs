       string request = "%" +  getTheBox + "%";
       string sqlText = "select * from fruits where fruitname LIKE @request"
       using(SqlConnection cn = GetSqlConnection())
       {
           cn.Open();
           using(SqlCommand cmd = new SqlCommand(sqlText, cm);
           {
                cmd.Parameters.AddWithValue("@request", request);
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                 ......
                }
           }
       }
