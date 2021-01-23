    Dictionary<string, List<string>> dict = new Dictionary<string,List<string>>();
    
    while (dbReader.Read())
    {
      string code = (string)dbReader["CODE"];
      string subject = (string)dbReader["SUBJECT"];
      foreach (string singleSubject in subject.Split(','))
      {
        if (!dict.ContainsKey(singleSubject))
        {
          dict.Add(subject, new List<string> { code });
        }
        else
        {
          dict[subject].Add(code);
        }
     }
    }
