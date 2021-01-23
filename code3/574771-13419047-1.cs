    interface IDependency2List
    {
        IEnumerable<IDependency2> Items;
    }
    interface IDependency2
    {
        //bla
    }
    public class A
    {
        public A(IDependency1 dep1, IDependency2List dep2List)
        {
    
        }
    }
