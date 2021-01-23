    class A { }
    class B : A { public int x; }
    class Program {
        static void Main() {
            A a;
            a = Ret();
            Out(out a, () => a = new A());
        }
        static B Ret() { return null; }
        static void Ref(ref B b) { }
        static void Out(out B b, Action callback) {
            b = new B();
            callback();
            b.x = 3; // cannot possibly work, b is an a again!
        }
    }
