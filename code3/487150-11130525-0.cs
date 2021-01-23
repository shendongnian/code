    RAMDirectory ramDir = new RAMDirectory();
    IndexWriter writer = new IndexWriter(ramDir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
    Document doc = new Document();
    Field tags = null;
    string [] articleTags = new string[] {"C#", "WPF", "Lucene" };
    foreach (string tag in articleTags)
    {   
        // adds a field with same name multiple times to the same document
        tags = new Field("tags", tag, Field.Store.YES, Field.Index.NOT_ANALYZED);
        doc.Add(tags);
    }
    writer.AddDocument(doc);
    writer.Commit();
    // search
    IndexReader reader = writer.GetReader();
    IndexSearcher searcher = new IndexSearcher(reader);
    // use an analyzer that treats the tags field as a Keyword (Not Analyzed)
    PerFieldAnalyzerWrapper aw = new PerFieldAnalyzerWrapper(new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
    aw.AddAnalyzer("tags", new KeywordAnalyzer());
    QueryParser qp = new QueryParser(Lucene.Net.Util.Version.LUCENE_29, "tags", aw);
    Query q = qp.Parse("+WPF +Lucene");
    TopDocs docs = searcher.Search(q, null, 100);
    Console.WriteLine(docs.totalHits); // 1 hit
    q = qp.Parse("+WCF +Lucene");
    docs = searcher.Search(q, null, 100);
    Console.WriteLine(docs.totalHits); // 0 hit
