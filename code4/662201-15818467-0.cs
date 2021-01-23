    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Lucene.Net.Search;
    using Lucene.Net.Index;
    using Lucene.Net.Analysis.Standard;
    using Lucene.Net.Documents;
    using Lucene.Net.Search.Spans;
    using Lucene.Net.Analysis;
    using Lucene.Net.Store;
    using System.IO;
    using Lucene.Net.QueryParsers;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                RAMDirectory dir = new RAMDirectory();
                IndexWriter iw = new IndexWriter(dir, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30), IndexWriter.MaxFieldLength.UNLIMITED);
                Document d = new Document();
                Field f = new Field("text", "This is some erfand erftyas poliot polioasd poliasdas data to test the wild card term enums. Lets see how it works out.", Field.Store.YES, Field.Index.ANALYZED);
                d.Add(f);
                iw.AddDocument(d);
                iw.Commit();
                IndexReader reader = iw.GetReader();
                QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "text", new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30));            
                // parser.MultiTermRewriteMethod = MultiTermQuery.CONSTANT_SCORE_BOOLEAN_QUERY_REWRITE;
                Query q= parser.Parse("(poli* && erf*) && test* && (asd* || res*) && aterm");
                Query q2 = parser.Parse("poli*");
                //var rq = q.Rewrite(reader);
                //ISet<Term> terms = new HashSet<Term>();
                //rq.ExtractTerms(terms);
                List<PrefixQuery> prefixQueries = null;
                if (q is PrefixQuery)
                {
                    prefixQueries = new List<PrefixQuery>();
                    prefixQueries.Add(q as PrefixQuery);
                }
                else if(q is BooleanQuery)
                {
                    prefixQueries = ExtractQueries(q as BooleanQuery);
                }
                foreach (var pq in prefixQueries)
                {
                    WildcardTermEnum termEnum = new WildcardTermEnum(reader, new Term(pq.Prefix.Field, pq.Prefix.Text + "*"));
                    if (termEnum.Term != null)
                        Console.WriteLine(termEnum.Term.Text);
                    while (termEnum.Next())
                    {
                        Console.WriteLine(termEnum.Term.Text);
                    }
                }
                Console.ReadLine();
            }
            private static List<PrefixQuery>  ExtractQueries (BooleanQuery query)
            {
                List<PrefixQuery> queries = new List<PrefixQuery>();
                foreach (var q in query)
                {
                    if (q.Query is BooleanQuery)
                    {
                        queries.AddRange(ExtractQueries(q.Query as BooleanQuery));
                    }
                    else
                    {
                        if (q.Query is PrefixQuery)
                        {
                            queries.Add(q.Query as PrefixQuery);
                        }
                    }
                }
                return queries;
            }
        }
    }
