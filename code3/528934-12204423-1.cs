    public class MyClass:IMyInterface
    {
       private Func<IMySoapClient> MySoapClientFactoryMethod;
    
       public MyClass(Func<IMySoapClient> clientFactoryMethod)
       {
          MySoapClientFactoryMethod = clientFactoryMethod;
       }
    
       ...
    
       public IMyInterface.SomeMethod()
       {    
            // hits a web service
            using ( mySoapClient client = MySoapClientFactoryMethod() )
            {
                 var someResult = client.DoSomething();
              ...
              ...
            }
       }
    }
