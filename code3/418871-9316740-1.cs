    string idString = "1,2,3,4";
    var ids = idString.Split(',').Select(x => int.Parse(x)).ToArray();
    for(int i =0;i< ids.Length;i++)
    {
      UpdateCmd.Parameters.Add(new SqlParameter("@flag"+i, SqlDbType.BigInt));
      UpdateCmd.Parameters["@flag"+i].Value = ids[i];
    }
