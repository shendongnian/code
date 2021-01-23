    StringBuilder sb = new StringBuilder();    
    while (dr.Read())
    {
      //put in a comma / break for the previous item
      sb.Append("insert into test values(N'"+dr[0]+"', N'"+dr[1]+"'),<br>");
    }
    sb.Remove(sb.Length-5,5); // remove the last ,<br>
    Response.Write(sb.ToString());
