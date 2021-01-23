    public abstract class MyClass
    {
        public void DoSomething()
        {
            Console.WriteLine("blah blah");
        }
    }
    
    public class MyClass<T>: MyClass
    {
        public T GetSomething()
        {
            // return null as T;
        }
    }
