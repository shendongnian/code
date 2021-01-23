    public abstract class MyClassBase : DllClass
    {
        protected override void MethodFromDll()
        {
           //here I inserted my code and it works ok
        }
    }
    ...
    public class MyClass : MyClassBase
    {
        // Whatever else you need
    }
