    RAMDirectory dir = new RAMDirectory();
    IndexWriter iw = new IndexWriter(dir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30), IndexWriter.MaxFieldLength.UNLIMITED);
    Document d = new Document();
    Field textField = new Field("text", "", Field.Store.YES, Field.Index.ANALYZED);
    d.Add(textField);
    Field idField = new Field("id", "", Field.Store.YES, Field.Index.NOT_ANALYZED);
    d.Add(idField);
    textField.SetValue("this is a document with a some words");
    idField.SetValue("42");
    iw.AddDocument(d);
    iw.Commit();
    IndexReader reader = iw.GetReader();
    SpellChecker.Net.Search.Spell.SpellChecker speller = new SpellChecker.Net.Search.Spell.SpellChecker(new RAMDirectory());
    speller.IndexDictionary(new LuceneDictionary(reader, "text"));
    string [] suggestions = speller.SuggestSimilar("dcument", 5);
    IndexSearcher searcher = new IndexSearcher(reader);
    foreach (string suggestion in suggestions)
    {
        TopDocs docs = searcher.Search(new TermQuery(new Term("text", suggestion)), null, Int32.MaxValue);
        foreach (var doc in docs.ScoreDocs)
        {
            Console.WriteLine(searcher.Doc(doc.Doc).Get("id"));
        }
    }
           
    reader.Dispose();
    iw.Dispose();
