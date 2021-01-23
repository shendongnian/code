    private static void AppendConstrain(StringBuilder query, string name, string value)
    {
        if (String.IsNullOrWhiteSpace(name))
            return;
    
        if (query.Length > 0)
            query.Append(" AND ");
        
        query.AppendFormat("{0} IN ({1})", name, value);
    }
