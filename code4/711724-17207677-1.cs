    string sqlQuery = "SELECT a.SomeId, b.SomeString, COUNT(*) AS SomeScalar"
                    + "FROM tblA a"
                    + "INNER JOIN tblB b ON a.SoneId = b.SomeId"
                    + "GROUP BY a.SomeId, b.SomeString"
                    + "WHERE b.SomeField = @SomeParameter";
    MyCustomQueryResult[] entries = CSDatabase.RunQuery<MyCustomQueryResult>(sqlQuery, new {SomeParameter:"123456"});
    foreach (MyCustomQueryResult entry in entries)
    {
       foreach (MappedObject mappedObject in entry.MappedObjects)
       {
           DoSomethingUseful(mappedObject);
       }
    }
