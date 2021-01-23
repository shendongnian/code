    var tblRooms = new DataTable();
    using(var con = new SqlConnection(connectionString))
    using (var da = new SqlDataAdapter(sql, con))
    {
        da.Fill(tblRooms);
    }
    Dictionary<string, Dictionary<string,string>> roomGroups =  tblRooms
        .AsEnumerable()
        .GroupBy(r => r.Field<string>("Room"))
        .ToDictionary(g => g.Key, g =>  g.ToDictionary(
            r => r.Field<string>("Item"), 
            r => r.Field<string>("Description")));
