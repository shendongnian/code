    var statesTables = new[]{"NY, Texas, Oregano, Alabama}";
    
    var qBuild = new StringBuilder();
    qBuild.Append(string.Format("SELECT * FROM {0} WHERE UserId = @userId ", statesTables[0]));
    for(int i=1;i<stateTables.Length;i++){
         qbuild.Append(string.Format("UNION SELECT * FROM {0} WHERE UserId = @userId ", statesTables[i]))
    }
    SqlConnection conn1 = new SqlConnection(connString);
    SqlCommand comm1 = new SqlCommand(qBuild.ToString(), conn1);
    comm1.Parameters.Add(new SqlParameter("userId", userId));
