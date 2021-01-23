    public class MyBase { }
    public class MyDerived1 : MyBase { }
    public class MyDerived2 : MyBase { }
    public interface IRetVal<out T> where T : MyBase { /* body omitted */ }
    public class Test
    {
        public IRetVal<T> GetRetValT<T>() where T : MyBase
        {
            return null;
        }
    }
    public class Class1
    {
        public void SomeFunc()
        {
            var test = new Test();
             var list = new List<Func<IRetVal<MyBase>>> 
            { 
                test.GetRetValT<MyDerived1>,
                test.GetRetValT<MyDerived2>
            };
        }
    }
