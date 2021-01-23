    using (var objConn = new SqlConnection(strConnection))
         {
            objConn.Open();
            using (var objCmd = new SqlCommand(strSQL, objConn))
            {
               using (var rsData = objCmd.ExecuteReader())
               {
                  rsData.Read();
                  if (rsData["usr.ursrdaystime"] != System.DBNull.Value)
                  {
                     strLevel = rsData["usr.ursrdaystime"].ToString();
                  }
               }
            }
         }
