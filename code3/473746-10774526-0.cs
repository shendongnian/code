    interface A { }
    static class AMixin {
        public static void aFunc(this A inst) {
            ... //implementation to work for all A.
        }
    }
    interface B { }
    static class BMixin {
        public static void bFunc(this B inst) {
            ...
        }
    }
    class Qux : Foo, A, B {
        ...
    }
