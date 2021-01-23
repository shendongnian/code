    DataTable dtDistricts = ConvertListToDataTable(Districts);
    SqlCommand insertCommand = new SqlCommand("usp_InsertDistricts", sqlConnection);
    SqlParameter p1 = insertCommand.Parameters.AddWithValue("@tvpNewDistricts", dtDistricts);
    p1.SqlDbType = SqlDbType.Structured;
    p1.TypeName = "dbo.DistrictsType";
    insertCommand.ExecuteNonQuery();
