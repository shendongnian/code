    public interface IMyInterface
    {
      void newMethod();
    }
    public class MyClass1 : IMyInterface
    {
        public void newMethod()
        {
          //Do what the method says it will do.
        }
    }
    public class Class1
    {
        public Class1()
        {
            MyClass1 classToSend = new MyClass1();
            test<IMyInterface>(classToSend);
        }
        public void test<T>(T MyClass) where T : IMyInterface
        {
            MyClass.newMethod();
        }
    }
