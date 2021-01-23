    ISolrConnection connection = ServiceLocator.Current.GetInstance<ISolrConnection>();
    List<KeyValuePair<string, string>> termsParams = new List<KeyValuePair<string, string>>();
    termsParams.Add(new KeyValuePair<string, string>("terms.fl", "name"));
    termsParams.Add(new KeyValuePair<string, string>("terms.prefix", mySearchString));
    termsParams.Add(new KeyValuePair<string, string>("terms.sort", "count"));
    string xml = connection.Get("/terms", termsParams);
    ISolrAbstractResponseParser<Document> parser = ServiceLocator.Current.GetInstance<ISolrAbstractResponseParser<Document>>();
    SolrQueryResults<Document> results = new SolrQueryResults<Document>();
    parser.Parse(System.Xml.Linq.XDocument.Parse(xml), results);
    TermsResults termResults = results.Terms;
    foreach (TermsResult result in termResults)
    {
        foreach (KeyValuePair<string, int> kvp in result.Terms)
        {
            //... do something with keys
        }
    }
