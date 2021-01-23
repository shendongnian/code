    public class Foo : IDispatch {
        public virtual void Dispatch() {
            whatever();
        }
    }
    public class Bar : Foo {
        public override void Dispatch() {
            whateverElse();
        }
    }
