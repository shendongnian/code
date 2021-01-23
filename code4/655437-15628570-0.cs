    DateTime dt;
    DateTime subline3Date;
    //...
    cmd = new SqlCommand("insert into closingStock values(?,?,?,?,?)", con);
    cmd.Parameters.Add(subLine[1]);
    cmd.Parameters.Add(subLine[2]);
    cmd.Parameters.Add(subline3Date);
    cmd.Parameters.Add(subLine[10]);
    cmd.Parameters.Add(dt);
    cmd.ExecuteNonQuery();
