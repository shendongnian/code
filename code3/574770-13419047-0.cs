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
        public A(IDependency2List dep2List)
        {
    
        }
    }
