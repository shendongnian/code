    public interface IFoo { }
    
    public class Foo : IFoo { }
    
    public class Bar : IFoo { }
    
    public interface CollectionOf<out T> : IEnumerable<IFoo> { }
    
    public class Bars : CollectionOf<Bar> { }
    
    public class Test
    {
        public void Test()
        {
            IEnumerable<IFoo> bars1 = new Bars();
            CollectionOf<IFoo> bars2 = new Bars();
        }
    }
