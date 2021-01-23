    public class Foo : IDispatch {
        void IDispatch.Dispatch() {
            this.Dispatch();
        }
        protected virtual void Dispatch() {
            whatever();
        }
    }
    public class Bar : Foo {
        protected override void Dispatch() {
            whateverElse();
        }
    }
