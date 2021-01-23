    string query = "select ?article ?mesh where { ?article a npg:Article . ?article npg:hasRecord [ dc:subject ?mesh ] . filter regex(?mesh, \"blood\", \"i\") }";
    NameValueCollection queries = new NameValueCollection();
    queries.Add("query", query);
    queries.Add("output", "sparql_json");
    using (WebClient wc = new WebClient())
    {
        wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
        wc.Headers.Add("Accept","application/json");
        wc.QueryString = queries;
        string result = wc.DownloadString("http://data.nature.com/sparql");
        Console.WriteLine(result);
    }
    Console.ReadLine();
