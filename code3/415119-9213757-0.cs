    SqlCommand insertCommand = new SqlCommand(sqlInsert, connection);
    SqlParameter tvpParam = insertCommand.Parameters.AddWithValue(
                                                               "@tvpNewCategories", 
                                                               addedCategories);
    tvpParam.SqlDbType = SqlDbType.Structured;
    tvpParam.TypeName = "dbo.CategoryTableType";
