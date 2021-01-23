    using(var conn = new SqlConnection(ConfigurationMananger
                             .ConnectionStrings["conn"].ConnectionString)
        using(cmd = conn.CreateCommand())
        {
            cmd.CommandText = 
            @"UPDATE Productios 
              SET CountryCode = (CASE 
                                    WHEN @SOffice IN('LA','GA') 
                                 THEN 'USA' ELSE 'CAN'
                                END),
                  ProvinceCode = @ProvinceCode
              WHERE ID = @newProductionID";
            cmd.Parameters.AddRange(new[]{
                new SqlParameter("SOffice",DbType.Char,2)
                    {
                        Value = "LA"
                    },
                new SqlParameter("ProvinceCode",DbType.Int)
                    {
                        Value = user.GetProvinceCode()
                    },
                new SqlParameter("newProductionID",DbType.Int)
                    {
                        Value = newProductionID
                    }
            });
            if(!conn.State == ConnectionState.Open)
                conn.Open();
            var resultCount = cmd.ExecuteNonQuery();
            
                                 
        }
    
