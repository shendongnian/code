    var query = new StringBuilder("SELECT * FROM Table1 WHERE");
    int qLength = query.Length;//if you don't want to count
    if (Condition1)
    {
        where.Append(" AND Col1=0");
    }
    if (Condition2)
    {
        where.Append(" AND Col2=0");
    }
    ....
    if (query.Length == qLength)
    {
        //if no condition remove where from string
        query.Length -= 6;
    }
