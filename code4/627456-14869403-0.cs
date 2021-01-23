    public abstract class A {
        public BarType Foo;
    
        public enum BarType {
            Value1,
            Value2
        }
    }
    
    public class B : A {
        public BarType Foo { get { return BarType.Value1; } }
    }
