    class APIEngine :IApiProvider
    {
        //...Private stuff & other methods
        Result[] Search(Key searchKey)
        {
           //Error handling ommitted
           Result[] result;
     
           ApiClient api = new ApiClient(); 
           api.Credentials.UserName.UserName = "blah";
           api.Credentials.UserName.Password = "blahblah";   
     
           object SomethingSearch search = new SomethingSearch(); 
           search.Key = searchKey;
     
           result = api.GetSomething(search);  
           api.Close();
          return result;
       }
    }
