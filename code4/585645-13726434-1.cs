    SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS2012;Initial
    Catalog=db;Integrated Security=true");
    conn.Open();
    List<SqlDataRecord> records = new List<SqlDataRecord>();
    var rec = new SqlDataRecord(new SqlMetaData("stringid", SqlDbType.NVarChar, 8));
    rec.SetValue(0, "10");
    records.Add(rec);
    rec = new SqlDataRecord(new SqlMetaData("stringid", SqlDbType.NVarChar, 8));
    rec.SetValue(0, "30");
    records.Add(rec);
    var cmd = new SqlCommand("SelectListValue");
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.Connection = conn;
    var param = new SqlParameter("@ids", SqlDbType.Structured);
    param.Direction = ParameterDirection.Input;
    param.TypeName = "StringIDList";
    param.Value = records;
    cmd.Parameters.Add(param);
    var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(reader.GetString(0));
    }
