<!-- -->
    class Program
    {
        private class CustomStandardAnalyzer : Analyzer
        {
            public override TokenStream TokenStream(string fieldName, System.IO.TextReader reader)
            {
                //create the tokenizer
                TokenStream result = new StandardTokenizer(Lucene.Net.Util.Version.LUCENE_30, reader);
                //add in filters
                result = new Lucene.Net.Analysis.Snowball.SnowballFilter(result, new EnglishStemmer()); 
                result = new LowerCaseFilter(result);
                result = new ASCIIFoldingFilter(result);
                result = new StopFilter(true, result, new HashSet<string>());
                return result;
            }
        }
        private static Document createDocument(string text)
        {
            Document d = new Document();
            Field f = new Field("text", "", Field.Store.YES, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);
            f.SetValue(text);
            d.Add(f);
            return d;
        }
        static void Main(string[] args)
        {
            RAMDirectory idx = new RAMDirectory();
            using (IndexWriter writer =
                new IndexWriter(
                    idx,
                    new CustomStandardAnalyzer(),
                    IndexWriter.MaxFieldLength.LIMITED))
            {
                writer.AddDocument(createDocument("some text with president and presidents"));
                writer.Commit();
            }
            using (var reader = IndexReader.Open(idx, true))
            {
                var terms = reader.Terms(new Term("text", ""));
                if (terms.Term != null)
                    do
                        Console.WriteLine(terms.Term);
                    while (terms.Next());
            }
            Console.ReadLine();
        }
    }
