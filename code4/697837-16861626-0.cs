    public static void Main (string[] args)
		{
			Analyzer analyser = new StandardAnalyzer (Lucene.Net.Util.Version.LUCENE_CURRENT);
			Directory dir = new RAMDirectory ();
			using (IndexWriter iw = new IndexWriter (dir, analyser, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED)) {
				Document doc1 = new Document ();
				doc1.Add (new Field("title", "multivalued", Field.Store.YES, Field.Index.ANALYZED));
				doc1.Add (new Field("multival", "val1", Field.Store.YES, Field.Index.ANALYZED));
				doc1.Add (new Field("multival", "val2", Field.Store.YES, Field.Index.ANALYZED));
				iw.AddDocument (doc1);
				Document doc2 = new Document ();
				doc2.Add (new Field("title", "singlevalued", Field.Store.YES, Field.Index.ANALYZED));
				doc2.Add (new Field("multival", "val1", Field.Store.YES, Field.Index.ANALYZED));		
				iw.AddDocument (doc2);
			}
			using (Searcher searcher = new IndexSearcher (dir, true)) {
				var q1 = new TermQuery (new Term ("multival", "val1"));
				var q1result = searcher.Search (q1, 1000);
				//Will print "Found 2 documents"
				Console.WriteLine ("Found {0} documents", q1result.TotalHits);
				var q2 = new TermQuery (new Term ("multival", "val2"));
				var q2result = searcher.Search (q2, 1000);
				//Will print "Found 1 documents"
				Console.WriteLine ("Found {0} documents", q2result.TotalHits);
			}
		}
