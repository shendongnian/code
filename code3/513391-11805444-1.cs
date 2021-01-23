    if (!string.IsNullOrEmpty(multiWordPhrase))
    {
       BooleanQuery bq = new BooleanQuery();
        
       string[] fieldList = { "Title", "Description", "Url" };
       List<BooleanClause.Occur> occurs = new List<BooleanClause.Occur>();
       foreach (string field in fieldList)
       {
          occurs.Add(BooleanClause.Occur.SHOULD);
       }
       Query qry = MultiFieldQueryParser.Parse(Version.LUCENE_29, multiWordPhrase, fieldList, occurs.ToArray(), new StandardAnalyzer(Version.LUCENE_29));
   
       bq.Add(qry,BooleanClause.Occur.Must);
        
       //this is the country query (modify the Country field name to whatever you have)
       string country = "UK";
       Query q2 = new QueryParser(Version.LUCENE_CURRENT, "Country", analyzer).parse(country);
       bq.Add(q2,BooleanClause.Occur.Must);
       searcher = new IndexSearcher(_directory, false);
            
       TopDocs topDocs = searcher.Search(bq, null, ((PageIndex + 1) * PageSize), Sort.RELEVANCE);
       ScoreDoc[] scoreDocs = topDocs.ScoreDocs;
       int resultsCount = topDocs.TotalHits;
       list.HasData = resultsCount;
       StartRecPos = (PageIndex * PageSize) + 1;
       if (topDocs != null)
       {
         //loop through your results
    
       }
