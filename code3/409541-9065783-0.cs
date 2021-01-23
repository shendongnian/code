      public interface IDependency {
          int DoSomething(SomeComplexType someComplexType,
                                int someInteger);
        }
    
        IList<object[]> argumentsSentToDoSomething = 
    dependency.GetArgumentsForCallsMadeOn(x => x.DoSomething(null, 0));
