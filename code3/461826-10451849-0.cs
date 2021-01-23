    if (Operator == Operator.Equal)     
    {     
        query = (from dr in dataTableToPage.AsEnumerable()     
                     select dr);     
        foreach (var pair in columnToExpression)
        {
           string columnFilter = pair.Item1;
           string expression = pair.Item2;
           query = query.Where (dr => dr[columnFilter].ToString() == expresion);
        }    
    }     
    else if(Operator == Operator.Like)     
    {     
        query = (from dr in dataTableToPage.AsEnumerable()     
                     select dr);     
        foreach (var pair in columnToExpression)
        {
           string columnFilter = pair.Item1;
           string expression = pair.Item2;
           query = query.Where (dr => dr[columnToFilter].ToString().IndexOf(expression,
                        StringComparison.OrdinalIgnoreCase) >= 0);
        }    
    }     
