    public class Foo {
        private readonly YourType tail;
        private readonly object syncLock = new object();
        public Foo(YourType tail) {this.tail = tail;}
        public A() { lock(syncLock) { tail.A(); } }
        public B() { lock(syncLock) { tail.B(); } }
        public C() { lock(syncLock) { tail.C(); } }
    }
