        class APIEngine :IApiProvider
        {
            //...Private stuff & other methods
            T[] Search<T>(SearchArgs args)
            {
               //Error handling ommitted
               T[] result;
               
               switch(args.SearchType)
               {
                   case(SearchType.GetSomething)
                        result = GetSomethingSearch(args.Key);
                        break;
                   // and so on
               }     
    
               
               api.Close();
              return result;
           }
           Result[] GetSomethingSearch(Key searchKey)
           {   
               ApiClient api = new ApiClient(); 
               api.Credentials.UserName.UserName = "blah";
               api.Credentials.UserName.Password = "blahblah";   
         
               object SomethingSearch search = new SomethingSearch(); 
               search.Key = searchKey;
         
               result = api.GetSomething(search);  
           }
        }
    
    
    class SearchArgs
    {
        SearchType SearchType {get; set;} //Enum of search types
        SearchKey Key {get; set;} //SearchKey would be parent class for different key types
    {
