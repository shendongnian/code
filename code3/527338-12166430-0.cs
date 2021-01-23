    IndexWriter iw = new IndexWriter(@"C:\temp\sotests", new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29), true);
    Document doc = new Document();
    Field loc = new Field("location", "", Field.Store.YES, Field.Index.NOT_ANALYZED);
    doc.Add(loc);
    loc.SetValue("chicago heights");
    iw.AddDocument(doc);
    loc.SetValue("new-york");
    iw.AddDocument(doc);
    loc.SetValue("chicago low");
    iw.AddDocument(doc);
    loc.SetValue("montreal");
    iw.AddDocument(doc);
    loc.SetValue("paris");
    iw.AddDocument(doc);
    iw.Commit();
    IndexSearcher ins = new IndexSearcher(iw.GetReader());
    WildcardQuery query = new WildcardQuery(new Term("location", "chicago he*"));
    var hits = ins.Search(query);
    for (int i = 0; i < hits.Length(); i++)
        Console.WriteLine(hits.Doc(i).GetField("location").StringValue());
    Console.WriteLine("---");
    query = new WildcardQuery(new Term("location", "chic*"));
    hits = ins.Search(query);
    for (int i = 0; i < hits.Length(); i++)
        Console.WriteLine(hits.Doc(i).GetField("location").StringValue());
    iw.Close();
    Console.ReadLine();
