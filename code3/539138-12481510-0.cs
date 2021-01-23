    namespace lib.CanModify
    {
        using lib.CanNotModify;
    
        public class Something
        {
            public void method()
            {
                method(new StaticClassWrapper());
            }
    
            public void method(IStaticClass staticClass)
            {
                var obj = staticClass.DoSomething();
            }
        }
    
        public interface IStaticClass
        {
            Node DoSomething();
        }
    
        public class StaticClassWrapper : IStaticClass
        {
            public Node DoSomething()
            {
                return lib.CanNotModify.StaticClass.DoSomething();
            }
        }
    
    }
