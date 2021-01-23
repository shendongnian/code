    string queryString;
    queryString = columnName;
    if(operator == Operator.LesserThan)
    {
      queryString += " < ";
    }
    else if (operator == Operator.GreaterThan)
    {
      queryString += " > ";
    }
    etc.
    queryString += age.ToString();  // Or use bind variables, haven't tried that myself in dynamic LINQ
    
    query = entites.Where(queryString);
