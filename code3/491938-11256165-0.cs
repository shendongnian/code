    class Program {
        class Class1 { }
        class Class2 { }
        public class MyGenericClass<TSomeClass> {
            public void MyGenericMethod<TSomeInterface>() where TSomeClass : TSomeInterface {
            }
        }
        static void Main(string[] args) {
            var inst = new MyGenericClass<Class1>();
        }
    }
