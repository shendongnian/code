	using System;
	using System.Collections.Generic;
	using Lucene.Net.Analysis;
	using Lucene.Net.Documents;
	using Lucene.Net.Index;
	using Lucene.Net.Search;
	using Lucene.Net.Store;
	using Directory = Lucene.Net.Store.Directory;
	using Version = Lucene.Net.Util.Version;
	namespace ConsoleApplication {
		public static class Program {
			public static void Main(string[] args) {
				var directory = new RAMDirectory();
				var analyzer = new KeywordAnalyzer();
				using (var writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED)) {
					var users = new [] { "Alfa", "Beta", "Gamma", "Delta" };
					var friendships = new Dictionary<String, String[]> {
						{ "Alfa", new [] { "Beta", "Gamma", "Delta" } },
						{ "Beta", new [] { "Gamma", "Delta" } },
						{ "Gamma", new [] { "Delta" } },
						{ "Delta", new String[0] } // Noone likes Delta.
					};
					foreach (var userName in users) {
						var doc = new Document();
						doc.Add(new Field("Name", userName, Field.Store.YES, Field.Index.NO));
						foreach (var friendName in friendships[userName]) {
							doc.Add(new Field("FriendsWith", friendName, Field.Store.NO, Field.Index.NOT_ANALYZED_NO_NORMS));
						}
						writer.AddDocument(doc);
					}
					writer.Commit();
				}
				// This should be the real query provided by the user (city, age, description, ...)
				var query = new MatchAllDocsQuery();
				// Create a filter limiting the result to those being friends with the current user,
				// in this example the user "Beta".
				var filter = new TermsFilter();
				filter.AddTerm(new Term("FriendsWith", "Gamma"));
				var reader = IndexReader.Open (directory, readOnly: true);
				var searcher = new IndexSearcher(reader);
				var result = searcher.Search (query, filter, 10);
				foreach(var topDoc in result.ScoreDocs) {
					var doc = searcher.Doc(topDoc.Doc);
					var foundName = doc.Get ("Name");
					Console.WriteLine("Matched user '{0}'", foundName);
				}
				Console.ReadLine();
			}
		}
	}
