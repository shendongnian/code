    public class DataService
        {
            IMyWebServiceClient _client;
    
             public  DataService(IMyWebServiceClient client)
              {
               _client=client
               }
    
              public  DataService():this(new MyWebServiceClient())
               {
    
               }
       
        
            public void Method1()
            {
               
                var v = _client.Operation1();
        
                ...
            }
        
            public void Method2()
            {
              
                var v = _client.Operation2();
        
                ...
            }
        }
