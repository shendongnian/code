    string Query="SELECT * FROM Table1 WHERE ";
    string QuerySub;
    if (condition1) QuerySub+="AND Col1=0 ";
    if (condition2) QuerySub+="AND Col2=1 ";
    if (condition3) QuerySub+="AND Col3=2 ";
    
    if (QuerySub.Substring.StartsWith("AND")
    {
           QuerySub = QuerySub.TrimStart("AND".ToCharArray());
    }
    
    Query= Query + QuerySub;
    
    if (Query.EndsWith("WHERE ")
    {
           QuerySub = QuerySub.TrimEnd("WHERE ".ToCharArray());
    }
    
