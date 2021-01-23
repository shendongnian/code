    int[] xs = { 2, 3, 5, 8, 13 };
    var c = new System.Data.SqlClient.SqlCommand();
    // this code assumes xs has always at least one item
    var s = new StringBuilder("SELECT … FROM … WHERE … IN (@xs0");
    c.Parameters.AddWithValue("@xs0", xs[0]);  
    for(int i = 1; i < xs.Length; i++)
    {
      s.AppendFormat(",@xs{0}", i);
      c.Parameters.AddWithValue(String.Format("@xs{0}",i), xs[i]);  
    }
    s.Append(")");
    c.CommandText = s.ToString():
