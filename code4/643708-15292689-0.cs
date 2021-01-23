    using Lucene.Net.Analysis;
    using Lucene.Net.Documents;
    using Lucene.Net.Index;
    using Lucene.Net.Store;
    
    ...
    
    Directory directory = FSDirectory.Open(new System.IO.DirectoryInfo(@"C:\\TestIndex"));
    
    var writer = new IndexWriter(
        directory, 
        new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29), 
        true, 
        new MaxFieldLength(int.MaxValue));
  
