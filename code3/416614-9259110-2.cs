    // value from cookie
    string groups = "2,10,99";
    // Build where clause and params
    List<string> where = new List<string>();
    List<SqlParameter> param = new List<SqlParameter>();
    foreach(string group in groups.Split(','))
    {
        int groupId = Int32.Parse(group);
        string paramName = string.Format("@Group{0}", groupId);
        where.Add(paramName);
        param.Add(new SqlParameter(paramName, groupId));
    }
    // create command
    SqlConnection myConnection = new SqlConnection("My ConnectionString");
    SqlCommand command = new SqlCommand("SELECT Files.Id, Files.Name, Files.Date, " +
                                "Files.Path, Files.[Group] " +
                                "FROM Files " +
                                "WHERE Files.[Group] in (" + string.Join(",", param) + ")" +
                                "ORDER BY Files.Id DESC", myConnection);
    command.Parameters.AddRange(param.ToArray());
