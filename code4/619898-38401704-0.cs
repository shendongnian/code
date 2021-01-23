    Use dtsearch ISearchStatusHandler interface with OnFound method, OnFound method Called each time a document is found 
    
    public class HomeController : Controller, ISearchStatusHandler
    {
       
    public void Search()
    {
       SearchJob sj = new SearchJob();
       sj.Request = "fast";
       sj.IndexesToSearch.Add(@"D:\R & D\Indexpath\aaa");
       sj.SearchFlags = SearchFlags.dtsSearchSynonyms &         
       SearchFlags.dtsSearchWordNetRelated;        
       sj.Execute();
       SearchResults result = sj.Results;
    }
    
     public void OnFound(SearchResultsItem item)
     {
            int DocId = item.DocId;
            string FileName = item.Filename;
     }
    
     public void OnSearchingFile(string filename)
     {
            throw new NotImplementedException();
     }
    
     public void OnSearchingIndex(string index)
     {
            throw new NotImplementedException();
     }
     }
