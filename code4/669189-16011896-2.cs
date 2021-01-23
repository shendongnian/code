      var userEmail = new List<string>();
      while (lobjDtReader.Read())
      {
           userEmail .Add(lobjDtReader[0].ToString());
      }
      var Emails = string.Join(",", userEmail );
