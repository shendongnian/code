    RAMDirectory dir = new RAMDirectory();
    IndexWriter iw = new IndexWriter(dir, new SnowballAnalyzer(Lucene.Net.Util.Version.LUCENE_30,"English"), IndexWriter.MaxFieldLength.UNLIMITED);
    Document d = new Document();
    Field f = new Field("text", "", Field.Store.YES, Field.Index.ANALYZED);
    d.Add(f);
    f.SetValue("He was born 1990 years");
    iw.AddDocument(d);
    iw.Commit();
    IndexReader reader = iw.GetReader();
    IndexSearcher searcher = new IndexSearcher(reader);
    QueryParser qp = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "text", new SnowballAnalyzer(Lucene.Net.Util.Version.LUCENE_30, "English"));
    Query q = qp.Parse("+born +1990");
    TopDocs td = searcher.Search(q, null, 25);
    foreach (var sd in td.ScoreDocs)
    {
        Console.WriteLine(searcher.Doc(sd.Doc).GetField("text").StringValue);
    }
    searcher.Dispose();
    reader.Dispose();
    iw.Dispose();
