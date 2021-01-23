    SqlDataReader dr = ...;
 
    if (dr.Read())
    {
      //no comma
      Response.Write("insert into test values(N'"+dr[0]+"', N'"+dr[1]+"')");
    }
    
    while (dr.Read())
    {
      //put in a comma / break for the previous item
      Response.Write(",<br>insert into test values(N'"+dr[0]+"', N'"+dr[1]+"')");
    }
