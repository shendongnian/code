    public interface IFoo {
        void Bar();
    }
    public class Foo : IFoo {
        void IFoo.Bar() { ... }
    }
