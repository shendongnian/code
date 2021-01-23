    public static Query IN(string fieldName, IEnumerable<string> values)
    {
        var q = new BooleanQuery();
        foreach (var val in values)
        {
            q.Add(new TermQuery(new Lucene.Net.Index.Term(fieldName, val)), BooleanClause.Occur.SHOULD);
        }
        return q;
    }
