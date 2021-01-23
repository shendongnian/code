        public class MyBaseClass  {}
        public class MyClass : MyBaseClass {}
        interface IB<out T>{}
        public class B<T> : IB<T> { }
        
        public class A<T> : B<T>   {}
        static void Main(string[] args)
        {
            IB<MyBaseClass> myVar = new A<MyClass>();
        }
