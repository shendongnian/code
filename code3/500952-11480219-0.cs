    interface MBar { }
    static class BarMethods {
        public static void M(this MBar self) { ... }
    }
    class Foo : MBar { ... }
