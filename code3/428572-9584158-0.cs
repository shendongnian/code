    foreach (string toFind in searchString)     
    {
       var searchResults = from a in dt.AsEnumerable()                             
                           where a.Field<string>("A").ToUpper().Contains(toFind.ToUpper()) 
    select new  object[] {
                     a.Field<Int32>("A"),                                 
                     a.Field<string>("B"),                                 
                     a.Field<string>("C"),                             
                 };
    
       foreach (var resultItem in searchResults
       {
          results.Rows.Add(resultItem);
       }
    }
