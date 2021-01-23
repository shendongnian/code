    query = (from dr in dataTableToPage.AsEnumerable()     
                 select dr);     
    // I'm not sure exactly what T you should be using in the following statement:
    // DataRow should be the type of dr
    var predicate = PredicateBuilder.False<DataRow>(); 
    foreach (var pair in columnToExpression)
    {
       string columnFilter = pair.Item1;
       string expression = pair.Item2;
       predicate = predicate.Or(dr => dr[columnFilter].ToString() == expresion);
    }    
    query = query.Where(predicate.Compile());
