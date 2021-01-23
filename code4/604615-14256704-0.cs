    public class A
    {
        public void MethodToCall(string args)
        {
            Console.WriteLine("I am class A - " + args);
        }
    }
    public class B
    {
        public B(Action<string> action)
        {
            Method = action;
        }
        public Action<string> MethodToCall { get; private set; }
    }
    ...
    var a = new A();
    var b = new B(a.MethodToCall);
    a.MethodToCall("A"); // I am class A - A
    b.MethodToCall("B"); // I am class A - B
