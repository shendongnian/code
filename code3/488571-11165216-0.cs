    DataTable SearchTable = new DataTable();
    DataColumn Title = new DataColumn("Title", typeof(System.String));
    DataColumn url = new DataColumn("url", typeof(System.String));
    SearchTable.Columns.Add(Title);
    SearchTable.Columns.Add(url);
    DataRow ResultRow = null;
    
    
    var bingContainer = new Bing.BingSearchContainer(new Uri("https://api.datamarket.azure.com/Bing/Search/"));
    var accountKey = "MyKey";
    
    // the next line configures the bingContainer to use your credentials.
    bingContainer.Credentials = new NetworkCredential(accountKey, accountKey);
    
    // now we can build the query
    var webQuery = bingContainer.Web(this.txtSearch.Text, null, null, null, null, null);
    
    var webResults = webQuery.Execute();
    
    foreach (var result in webResults)
    {
    
    
        ResultRow = SearchTable.NewRow();
        ResultRow["Title"] = result.Title;
        ResultRow["url"] = result.Url;  //I want this Field as a HyperLink
    
        SearchTable.Rows.Add(ResultRow);
    }
    
    grdResult.DataSource = SearchTable;
    grdResult.DataBind();
    
