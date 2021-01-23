    class BaseClass 
    {
       protected HashSet<BaseClass> container;
       public DoSomething()
       {
           container.Add(new BaseClass());   // not legal if container is really a List<DerivedClass>
       }
    }
    
