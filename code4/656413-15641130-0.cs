    var links = new Dictionary<string, string>
    			{
    				{ "http://fhfa.gov/weblink/POSummary.xls", @"c:\temp\POSummary.xls" },
    				{ "...", "..."}
    			};
    var webClient = new WebClient();
    foreach (var kvp in links)
    {
    	webClient.DownloadFile(kvp.Key, kvp.Value);
    }
