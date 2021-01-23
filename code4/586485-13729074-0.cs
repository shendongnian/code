    public class Foo
    {
        public int Value { get; set; }
        public static bool operator ==(Foo first, Foo second)
        {
            return first.Value == second.Value;
        }
    }
