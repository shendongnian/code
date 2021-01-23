    public abstract class Parent<T> where T : Parent {
        public void DoSomething() {
            var c = new GenericClass<T>();
            c.DoYourThing();
        }
     }
    public class Child : Parent<Child> {}
