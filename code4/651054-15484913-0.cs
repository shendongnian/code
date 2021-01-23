    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Lucene.Net.Analysis;
    using Lucene.Net.Analysis.Standard;
    using Lucene.Net.Documents;
    using Lucene.Net.Index;
    using Lucene.Net.Search;
    using Lucene.Net.Store;
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                RAMDirectory dir = new RAMDirectory();
                var perFieldAnalyzer = new PerFieldAnalyzerWrapper(new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30));
                perFieldAnalyzer.AddAnalyzer("ExactTitle", new LowercaseKeywordAnalyzer());
                IndexWriter indexWriter = new IndexWriter(dir, perFieldAnalyzer, IndexWriter.MaxFieldLength.UNLIMITED);
                Document reportDoc = new Document();
                Field exactTitleField = new Field("ExactTitle", 
                                                    "Test Abc", 
                                                    Field.Store.NO,
                                                    Field.Index.ANALYZED);
                reportDoc.Add(exactTitleField);
                indexWriter.AddDocument(reportDoc);
                indexWriter.Commit();
                IndexSearcher searcher = new IndexSearcher(indexWriter.GetReader());
                var term = new Term("ExactTitle", "test abc"); //note: for this to work this way you need to always lower case the search too
                var exactQuery = new TermQuery(term);
                var hits = searcher.Search(exactQuery, null, 25, Sort.RELEVANCE);
                Console.WriteLine(hits.TotalHits); // prints "1"
                Console.ReadLine();
                indexWriter.Close();
            }
            public class LowercaseKeywordAnalyzer : Analyzer
            {
                public override TokenStream TokenStream(string fieldName, System.IO.TextReader reader)
                {
                    TokenStream tokenStream = new KeywordTokenizer(reader);
                    tokenStream = new LowerCaseFilter(tokenStream);
                    return tokenStream;
                }
            }
        }
    }
