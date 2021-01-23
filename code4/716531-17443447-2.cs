    var query = new StringBuilder("SELECT * FROM Table1 WHERE");
    int qLength = query.Length;//if you don't want to count :D
    if (Condition1)
    {
        query.Append(" Col1=0 AND");
    }
    if (Condition2)
    {
        query.Append(" Col2=0 AND");
    }
    ....
    //if no condition remove WHERE or AND from query
    query.Length -= query.Length == qLength ? 6 : 4;
