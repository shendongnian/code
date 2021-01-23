    public interface IParent {}
    public abstract class Parent<T> : IParent where T : IParent {
        public void DoSomething() {
            var c = new GenericClass<T>();
            c.DoYourThing();
        }
     }
    public class Child : Parent<Child> {}
