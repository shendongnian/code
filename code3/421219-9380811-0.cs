        public class MyBaseClass  {}
        public class MyClass : MyBaseClass {}
        public class B<T> { }
        
        public class A<T> : B<T>   {}
        static void Main(string[] args)
        {
            //Does not compile
            B<MyBaseClass> myVar = new A<MyClass>();
        }
