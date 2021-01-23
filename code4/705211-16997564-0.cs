    int[] xs = { 2, 3, 5, 8, 13 };  // I've also tried using a List<int> instead
    var c = new System.Data.SqlClient.SqlCommand();
    var s = new StringBuilder("SELECT … FROM … WHERE … IN (");
     for(int i=0; i < xs.Length; i++)
    {
      c.Parameters.AddWithValue(String.Format("@xs{0}",i), xs[i]);  
      s.AppendFormat("@xs{0},",i);
    }
    s.Remove(s.Length-1); // remove last comma
    s.Append(")");
    c.CommandText = s.ToString():
