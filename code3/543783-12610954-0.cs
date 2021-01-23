    string sqlquery = "SELECT Q1, Q2, Q3, Q4, Improvements, Comments FROM pid_FluSurvey";
    conn.Open();
    SqlDataAdapter cmd = new SqlDataAdapter(sqlquery, conn);
    SqlCommand comd = new SqlCommand(sqlquery, conn);
    DataSet myData = new DataSet();
    cmd.Fill(myData, "myTable");
    comd.CommandText = "SELECT COUNT(*) FROM pid_FluSurvey";
    Int32 count = (Int32)comd.ExecuteScalar();
    comd.ExecuteNonQuery();
    conn.Close();
    return JsonConvert.SerializeObject( new { result=myData, count = count }, Formatting.Indented,
        new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });
