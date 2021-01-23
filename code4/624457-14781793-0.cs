    // Example original implementation of foo() in class Bar
    class Bar {
        public void foo(string[] s) {
            foreach (var s1 in s) {
                Console.WriteLine(s1);                
            }
        }
    }
    // Your extension of foo()
    static class FooExtensions {
        public static void foo(this Bar bar, string s) {
            bar.foo(new[] {s});
        }
    }
    class Program {
        static void Main() {
            var bar = new Bar();
            string s = "hello";
            bar.foo(s); // This is how you wanted to call it 
        }
    }
