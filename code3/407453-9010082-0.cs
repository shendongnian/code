    Query GetQuery(string querystring)
    {
       Search.Search.BooleanQuery query = new Search.Search.BooleanQuery();
       Search.Analysis.TokenStream tk = StandardAnalyzerInstance.TokenStream(null, new StringReader(querystring));
       Search.Analysis.Tokenattributes.TermAttribute ta = tk.GetAttribute(typeof(Search.Analysis.Tokenattributes.TermAttribute)) as Search.Analysis.Tokenattributes.TermAttribute;
        while (tk.IncrementToken())
        {
             string term = ta.Term();
             Search.Search.BooleanQuery bq = new Search.Search.BooleanQuery();
             bq.Add(new Search.Search.TermQuery(new Search.Index.Term("fieldToQuery", term)), Search.Search.BooleanClause.Occur.SHOULD);
             bq.Add(new Search.Search.PrefixQuery(new Search.Index.Term("fieldToQuery", term)), Search.Search.BooleanClause.Occur.SHOULD);
             bq.Add(new Search.Search.FuzzyQuery(new Search.Index.Term("fieldToQuery", term)), Search.Search.BooleanClause.Occur.SHOULD);
             query.Add(bq, Search.Search.BooleanClause.Occur.MUST);
        }
        return query;
    }
