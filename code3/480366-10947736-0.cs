      using (
               var oConn =
                   new SqlConnection(
                       ConfigurationManager.ConnectionStrings["myConnectionStringNameFromWebConfig"].ConnectionString)
               )
            {
                oConn.Open();
                using (SqlCommand oCmd = oConn.CreateCommand())
                {
                    oCmd.CommandType = CommandType.StoredProcedure;
                    oCmd.CommandText = "p_jl_GetThemeForPortal";
                    oCmd.Parameters.Add(new SqlParameter("@gClientID", clientID));
				}
				
				 using(var oDR = oCmd.ExecuteReader())
                    {
                        while(oDR.Read())
                        {
                            string x = (string)oDR["ColumnName"];
                            int y = (int) oDR["ColumnName2"];
                            // Do something with the string and int
                        }
                    }
					
			}
