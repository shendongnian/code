    class Program
    {
        static void Main(string[] args)
        {
            Directory directory = FSDirectory.Open(new DirectoryInfo(this.IndexPath));
            StandardAnalyzer analyzer = new StandardAnalyzer(Version.LUCENE_29);
            var writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
            writer.Optimize();
            writer.Commit();
            writer.Close();
            String text1 = "C:\\Users\\Marto\\Desktop\\folder1\\file1.txt";
            WriteDocument(text1);
            SearchSomething("C:\\Users\\Marto\\Desktop\\folder1\\file1.txt");
            Console.ReadLine();
        }
        private static void WriteDocument(String text)
        {
            Directory directory = FSDirectory.Open(new DirectoryInfo("LuceneIndex"));
            StandardAnalyzer analyzer = new StandardAnalyzer(Version.LUCENE_29);
            IndexWriter writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED);
            Document doc = new Document();
            doc.Add(new Field("path", text, Field.Store.YES, Field.Index.NOT_ANALYZED));
            writer.AddDocument(doc);
            writer.Optimize();
            writer.Commit();
            writer.Close();
        }
        private static void SearchSomething(String searchText)
        {
            Directory directory = FSDirectory.Open(new DirectoryInfo("LuceneIndex"));
            StandardAnalyzer analyzer = new StandardAnalyzer(Version.LUCENE_29);
            IndexSearcher searcher = new IndexSearcher(directory, true);
            int results = 0;
            if (searcher.MaxDoc() > 0)
            {
                BooleanQuery booleanQuery = new BooleanQuery();
                Lucene.Net.Search.Query query1 = new WildcardQuery(new Term("path", searchText));
                booleanQuery.Add(query1, BooleanClause.Occur.SHOULD);
                TopDocs topDocs = searcher.Search(booleanQuery, searcher.MaxDoc());
                results = topDocs.ScoreDocs.Length;
                Console.WriteLine("Found {0} results", results);
                for (int i = 0; i < results; i++)
                {
                    ScoreDoc scoreDoc = topDocs.ScoreDocs[i];
                    float score = scoreDoc.Score;
                    int docId = scoreDoc.Doc;
                    Document doc = searcher.Doc(docId);
                    Console.WriteLine("Result num {0}, score {1}", i + 1, score);
                    Console.WriteLine("Text found: {0}\r\n", doc.Get("path"));
                }
            }
            searcher.Close();
            directory.Close();
        }
    }
