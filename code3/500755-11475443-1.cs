    using (OdbcDataReader reader = com.ExecuteReader()) {
      if (reader.HasRows())
      {
        string finalstring = "";
        while (reader.Read()) {
          finalstring = finalstring + reader.GetString(9) + ",";
          for (int i = 0; i <= 8; i++) {
            finalstring = finalstring + reader.GetValue(i).ToString() + ",";
          }
          finalstring = finalstring + "|";
        }
        if (finalstring != "") {
          finalstring = finalstring.Remove(finalstring.Length -1, 1);
          Response.Write(finalstring);
        }
      }
   }
