    Query queryTerm = new TermQuery(new Term("word", searchedWord));
    Query query1 = new TermQuery(new Term("category", NumericUtils.IntToPrefixCoded(0)));
    Query query2 = new TermQuery(new Term("category", NumericUtils.IntToPrefixCoded(1));
    
    BooleanQuery innerOrQuery = new BooleanQuery();
    innerOrQuery.Add(query1, BooleanClause.Occur.SHOULD);
    innerOrQuery.Add(query2, BooleanClause.Occur.SHOULD);
    
    BooleanQuery mainQuery = new BooleanQuery();
    mainQuery.Add(queryTerm, BooleanClause.Occur.MUST);
    mainQuery.Add(innerOrQuery, BooleanClause.Occur.MUST);
    
    TopDocs topDocs = _indexSearcher.Search(mainQuery, Settings.Current.MaximumTopScoreCount);
