    var cmd = new SqlCommand(CommandText = "prc_update",conn);
    ...
    var dt = new DataTable();
    dt.Columns.Add("crc32",typeof(string));
    ..... you can add more if you like
    foreach(var item in myList)
    {
      var row = dt.NewRow();
      row["crc32"] = item;
      dt.Rows.Add(row);
    }
    cmd.Parameters.Add("@tvp", System.Data.SqlDbType.Structured);
    cmd.Parameters["@tvp"].Value = dt;
    .....
    conn.Open();
    cmd.ExecuteNonQuery();
