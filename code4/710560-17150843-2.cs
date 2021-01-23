You'd have to do it a little differently. In Dapper, it matches on convention AKA property of field names being identical to SQL parameters. So, assuming you had a MyObject:
    public class MyObject
    {
        public int A { get; set; }
        public string B { get; set; }
    }
And assuming processList = List&lt;MyObject&gt;, You'd want to do this
    foreach (var item in processList)
    {
        string processQuery = "INSERT INTO PROCESS_LOGS VALUES (@A, @B)";        
        connection.Execute(processQuery, item);
    }
Note that the MyObject property names A and B match the SQL parameter names @A and @B.
