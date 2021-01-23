    public static Query In(string fieldName, IEnumerable<string> values)
    {
        var query = new BooleanQuery();
        foreach (var val in values)
        {
            query.Add(new TermQuery(new Lucene.Net.Index.Term(fieldName, val)), BooleanClause.Occur.SHOULD);
        }
        return query;
    }
