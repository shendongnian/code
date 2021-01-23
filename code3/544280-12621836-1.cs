    int mis=1652908150;
    //create the dataTable
    dt = new DataTable();
    dt.Columns.Add("crc32", typeof(int));
    var row = dt.NewRow();
    row["crc32"] = mis; // I do not see the point of convert.
    dt.Rows.Add(row);
    //exec the proc
    var cmd = new SqlCommand("UpdateAdsList",con);
    cmd.CommandType = Syste.Data.CommandType.StoredProcedure;
    cmd.Parameters.AddWithValue("@tvp",dt);
    con.Open();
    int misRow=cmd.ExecuteNonQuery();
    con.close();
