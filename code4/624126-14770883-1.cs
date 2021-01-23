    var mySet = new SortedSet<string>();
    
    while(dbReader.Read())
    {
      if(dbReader["GenSubject"] != DBNull.Value)
      {
        var generalSubject = (string)dbReader["GenSubject"];
        if(!generalSublject.Equals("No related topics"))
        {
          mySet.Add(generalSubject); // returns false if already in Set
        }
        else
        {
          // do nothing
        }
    }
