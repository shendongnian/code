        class Foo
        {
            public int? i { get; set; }
        }
        static class Program
        {
            static void Main()
            {
                var f = new Foo();
                var p = f.GetType().GetProperty("i", 
                    BindingFlags.Instance | BindingFlags.Public);
                f.i = 5;
                var v = p.GetValue(f, null);
                p.SetValue(f, 3, null);
            }
        }
