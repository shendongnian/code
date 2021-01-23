    public class Foo : IAngles {
        public IAngles Angles { get { return this; } }
        double IAngles.this[int index] { get { ... } }
    }
    public interface IAngles {
        double this[int index] { get;}
    }
