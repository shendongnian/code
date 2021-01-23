    static class BarExtensions {
        public static void foo(this Bar bar, string s) {
            bar.foo(new[] {s});
        }
    }
