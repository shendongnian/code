    public class SomeClass
    {
        public void Foo()
        {
            var a = new Random().Next();
        }
    }
    public class MyUnitTest
    {
        public void MyTestMethod()
        {
            var target = new SomeClass();        
            target.Foo(); // What to assert, what is the result?..
        }
    }
