    public abstract class Graph {
        public abstract void SomeMethod();
    }
    
    public interface IDataTip {
        void SomeMethod();
    }
    
    public class MyClassDerivedFromGraph: Graph, IDataTip {
        void SomeMethod() {
           // This method matches both the interface method and the base class method.
        }
    }
