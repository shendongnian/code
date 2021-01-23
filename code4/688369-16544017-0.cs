    public interface IFooBase { /* Interface contract... */ }
    public class ConcreteFooA : IFooBase { /* Implement interface contract */ }
    public class ConcreteFooB : IFooBase { /* Implement interface contract */ }
    // Some class that acts on IFooBases
    public class ActionClass
    {
        public ActionClass(IFooBase fooBase) { this._fooBase = foobase };
        public DoSomething() { /* Do something useful with the FooBase */ }
        // Or, you could use method injection on static methods...
        public static void DoSomething(IFooBase fooBase) { /* Do some stuff... */ }
    }
