    using (OdbcDataReader reader = com.ExecuteReader()) {
      if (reader.HasRows())
      {
        while (reader.Read()) {
          string finalstring = "";
          finalstring = reader.GetString(9) + ",";
          for (int i = 0; i <= 8; i++) {
            finalstring = finalstring + reader.GetValue(i).ToString() + ",";
          }
          /* Not sure about pipe here; its taken away in next line? */
          finalstring = finalstring + "|";
          if (finalstring != "") {
            /* Not sure of the intent here - this just removes your pipe character? */
            finalstring = finalstring.Remove(finalstring.Length -1, 1);
            Response.Write(finalstring);
          }
        }
      }
   }
