    DataTable tblResult = new DataTable();
    string sql = "SELECT * FROM dbo.TableName WHERE Date BETWEEN @startDate AND @endData";
    using (var con = new SqlConnection(connectionString))
    using (var cmd = new SqlCommand(sql, con))
    using (var da = new SqlDataAdapter(cmd))
    {
        // asuming that your startdate is three months ago and your enddate is now
        cmd.Parameters.AddWithValue("@startDate", DateTime.Now.AddMonths(-3));
        cmd.Parameters.AddWithValue("@endDate", DateTime.Now);
        da.Fill(tblResult);
    }
