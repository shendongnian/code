    public IMyInterface.SomeMethod(Func<IMySoapClient> clientFactory)
    {    
         // hits a web service
         using ( mySoapClient client = clientFactory() )
         {
              var someResult = client.DoSomething();
           ...
           ...
         }
    }
