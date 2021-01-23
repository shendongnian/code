    public abstract class Parent<T> : IParent
    {
        public void DoSomething() {
            var c=new GenericClass<T>();
            c.DoYourThing();
        }
    }
    
    public sealed class Child : Parent<Child>
    {
    }
