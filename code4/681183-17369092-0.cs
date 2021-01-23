    // Create the Client
    string indexName = "testindex";
    var uri = new Uri("http://localhost:9200");
    var settings = new ConnectionSettings(uri).SetDefaultIndex(indexName);
    var client = new ElasticClient(settings);
    // Create new Index Settings
    IndexSettings set = new IndexSettings();
    // Create a Custom Analyzer ...
    var an = new CustomAnalyzer();
    // ... based on the standard Tokenizer
    an.Tokenizer = "standard";
    // ... with Filters from the StandardAnalyzer
    an.Filter = new List<string>();
    an.Filter.Add("standard");
    an.Filter.Add("lowercase");
    an.Filter.Add("stop");
    // ... just adding the additional AsciiFoldingFilter at the end
    an.Filter.Add("asciifolding");
    // Add the Analyzer with a name
    set.Analysis.Analyzers.Add("nospecialchars", an);
    // Create the Index
    client.CreateIndex(indexName, set);
