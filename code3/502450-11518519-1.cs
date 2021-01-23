    SqlCommand cmd = new SqlCommand(pCommandText, GetConnection());
    cmd.Parameters.Clear();
    List<SqlParameter> list = new List<SqlParameter>();
    list.Add(new SqlParameter("@p1", value1));
    list.Add(new SqlParameter("@p2", value2));
    list.Add(new SqlParameter("@p3", value3));
    cmd.Parameters.AddRange(list.ToArray<SqlParameter>());
