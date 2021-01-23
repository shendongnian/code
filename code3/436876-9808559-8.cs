    //Definitions
    public interface ITest<T> {}
    
    public class Test<T> : ITest<T> {}
    
    //Component registration
    container.Register(Component.For(typeof(ITest<>)).ImplementedBy(typeof(Test<>)));
    
    //Dependency
    public class ComponentDependentOnTest
    {
        public ComponentDependentOnTest(ITest<int> test)
        {}
    }
