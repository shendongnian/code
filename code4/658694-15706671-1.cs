       string request = "%" +  getTheBox + "%";
       string sqlText = "SELECT Recipe_Name FROM New_Recipe WHERE ingredient1 LIKE @request";
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
