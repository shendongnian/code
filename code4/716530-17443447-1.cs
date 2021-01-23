    var query = new StringBuilder("SELECT * FROM Table1 WHERE");
    int qLength = query.Length;//if you don't want to count :D
    if (Condition1)
    {
        query.Append(" AND Col1=0");
    }
    if (Condition2)
    {
        query.Append(" AND Col2=0");
    }
    ....
    //if no condition remove where from string
    if (query.Length == qLength)
    {
        query.Length -= 6;
    }
