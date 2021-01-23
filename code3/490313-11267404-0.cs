    var searchTerms = "John Doe".Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    
    var query = session.Advanced.LuceneQuery<Person, PersonIndex>();
    query = query.OpenSubclause(); // optional
    
    foreach (var term in terms)
    {
    	query = query.WhereStartsWith("FirstName"), term).OrElse();
    	query = query.WhereStartsWith("LastName"), term).OrElse();
    }
    
    query = query.WhereEquals("Id", null);
    query = query.CloseSubclause(); // if OpenSubclause() was used
